using Ekzakt.EmailSender.Core.Contracts;
using Ekzakt.EmailSender.Core.Models;
using Ekzakt.EmailSender.Core.Models.Requests;
using Ekzakt.Utilities.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Smooth.Flaunt.Api.Hubs;
using Smooth.Shared.Endpoints;
using Smooth.Shared.Models.Requests;
using Smooth.Shared.Models.Responses;

namespace Smooth.Flaunt.Api.Controllers;


[Route(Ctrls.TRIAL)]
[ApiController]
public class TrialController(
    IHubContext<NotificationsHub> _notificationsHub,
    IEkzaktEmailSenderService _emailSenderService
    ) : ControllerBase
{
    [HttpPost]
    [Route(Routes.POST_TEXTCLASS)]
    public async Task<IActionResult> InsertTestClassAsync(InsertTestClassRequest request)
    {
        var output = await Task.Run(() =>
        {
            var result = IntHelpers.GetRandomPositiveInt();

            return result;
        });

        await _notificationsHub.Clients.All.SendAsync("MessageReceived", output);

        return Ok(new InsertTestClassResponse { Id = output });
    }



    [HttpGet]
    [Route(Routes.POST_TRIGGER_EMAIL)]
    public async Task<IActionResult> TriggerEmailAsync()
    {
        SendEmailRequest request = new();

        request.Email.Tos.Add(new EmailAddress("mail@ericjansen.com", "Eric Jansen"));
        request.Email.Subject = "Send email trigger from TestController.";
        request.Email.Body.Html = "<h1>Header</h1><p>Body</p>";
        request.Email.Body.Text = "TextBody";

        var result = await _emailSenderService.SendAsync(request);

        return Ok(new TriggerEmailResponse { Response = result.ServerResponse });
    }
}
