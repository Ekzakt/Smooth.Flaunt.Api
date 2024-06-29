using AutoMapper;
using Ekzakt.FileManager.Core.Contracts;
using Ekzakt.FileManager.Core.Models.EventArgs;
using Ekzakt.FileManager.Core.Models.Requests;
using Ekzakt.FileManager.Core.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using Smooth.Flaunt.Api.Hubs;
using Smooth.Flaunt.Api.Utilities;
using Smooth.Flaunt.Shared.Endpoints;
using Smooth.Flaunt.Shared.Models.Dtos;
using Smooth.Flaunt.Shared.Models.HubMessages;
using Smooth.Flaunt.Shared.Models.Requests;
using Smooth.Flaunt.Shared.Models.Responses;
using System.Text.Json;
using System.Web;

namespace Smooth.Flaunt.Api.Controllers;

[Route(Ctrls.FILES)]
[ApiController]

public class FilesController(
    IMapper _mapper,
    IHubContext<ProgressHub> _progressHub,
    IEkzaktFileManager _fileMananager)
    : ControllerBase
{
    [HttpGet]
    [Route(Routes.GET_FILES)]
    public async Task<IActionResult> GetFilesListAsync(CancellationToken cancellationToken)
    {
        var result = await _fileMananager.ListFilesAsync(new ListFilesRequest(), cancellationToken);

        var mapResult = _mapper.Map<List<FileInformationDto>>(result.Data);
        var output = new GetFilesListResponse { Files = mapResult };

        var isSuccess = result.IsSuccess();
        var statusCode = (int)result.Status;

        return isSuccess
            ? Ok(output)
            : StatusCode(statusCode, output);
    }


    [HttpDelete]
    [Route(Routes.DELETE_FILE)]
    public async Task<IActionResult> DeleteFileAsync(string fileName, CancellationToken cancellationToken)
    {
        fileName = HttpUtility.UrlDecode(fileName);

        var request = new Ekzakt.FileManager.Core.Models.Requests.DeleteFileRequest
        {
            FileName = fileName
        };

        var result = await _fileMananager.DeleteFileAsync(request, cancellationToken);

        return Ok(new DeleteFileResponse { IsSuccess = result.IsSuccess() });
    }


    [HttpPost]
    [Route(Routes.POST_FILE)]
    public async Task<IActionResult> SaveFileAsync(IFormFile file, Guid id, CancellationToken cancellationToken)
    {
        using var fileStream = file.OpenReadStream();

        var request = new SaveFileRequest
        {
            FileName = $"{id}.jpg",
            FileStream = fileStream,
            ProgressHandler = GetSaveFileProgressHandler(id),
            InitialFileSize = fileStream.Length
        };

        var result = await _fileMananager.SaveFileAsync(request, cancellationToken);

        if (result.IsSuccess())
        {
            return Ok(new PostFileResponse { FileId = id });
        }
        else
        {
            return BadRequest(result.Message);
        }
    }



    [HttpPost]
    [Route(Routes.POST_FILE_STREAM)]
    [DisableRequestSizeLimit, RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue, ValueLengthLimit = int.MaxValue)]
    [MultipartFormData]
    [DisableFormValueModelBinding]
    public async Task<ActionResult<HttpResponseMessage>> SaveFileStreamAsync(CancellationToken cancellationToken)
    {
        var httpRequest = HttpContext.Request;
        var contentType = httpRequest?.ContentType;
        var result = new FileResponse<string?>();

        if (httpRequest is null || contentType is null)
        {
            throw new InvalidDataException($"{nameof(httpRequest.ContentType)} is null.");
        }

        var boundary = GetMultipartBoundary(MediaTypeHeaderValue.Parse(contentType));
        var multipartReader = new MultipartReader(boundary, httpRequest.Body);
        var saveFileRequest = new SaveFileRequest();

        var section = await multipartReader.ReadNextSectionAsync();

        while (section != null)
        {
            var contentDisposition = section.GetContentDispositionHeader();

            if (contentDisposition!.IsFormDisposition())
            {
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var jsonString = await section.ReadAsStringAsync(cancellationToken);
                var jsonContent = JsonSerializer.Deserialize<SaveFileFormContentRequest>(jsonString, jsonOptions);

                saveFileRequest.ContentType = jsonContent!.FileContentType;
                saveFileRequest.InitialFileSize = jsonContent!.InitialFileSize;
            }
            else if (contentDisposition!.IsFileDisposition())
            {
                saveFileRequest.FileName = contentDisposition!.FileName.Value ?? string.Empty;
                saveFileRequest.FileStream = section.Body;
                saveFileRequest.ProgressHandler = GetSaveFileProgressHandler(Guid.NewGuid());

                result = await _fileMananager.SaveFileAsync(saveFileRequest, cancellationToken);
            }
            else
            {
                throw new InvalidOperationException("Invalid ContentDisposition.");
            }

            section = await multipartReader.ReadNextSectionAsync();
        }

        return new HttpResponseMessage(result.Status);
    }




    #region Helpers


    private Progress<ProgressEventArgs> GetSaveFileProgressHandler(Guid progressId)
    {
        var progressHandler = new Progress<ProgressEventArgs>(async progress =>
        {
            await _progressHub.Clients.All.SendAsync("ProgressUpdated", new ProgressHubMessage
            {
                PercentageDone = progress.PercentageDone,
                ProgressId = progressId
            });
        });

        return progressHandler;
    }


    private string GetMultipartBoundary(MediaTypeHeaderValue contentType)
    {
        var boundary = HeaderUtilities.RemoveQuotes(contentType.Boundary).Value;

        if (string.IsNullOrWhiteSpace(boundary))
        {
            throw new InvalidDataException("Missing content-type boundary.");
        }

        return boundary;
    }


    #endregion Helpers
}
