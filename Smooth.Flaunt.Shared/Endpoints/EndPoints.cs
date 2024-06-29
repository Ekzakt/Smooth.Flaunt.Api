using Smooth.Flaunt.Shared.Models.Requests;
using System.Web;

namespace Smooth.Flaunt.Shared.Endpoints;

public static class EndPoints
{

    // Test 
    public static string INSERT_TESTCLASS() => $"{Ctrls.TRIAL}/{Routes.POST_TEXTCLASS}";
    public static string TRIGGER_EMAIL() => $"{Ctrls.TRIAL}/{Routes.POST_TRIGGER_EMAIL}";
    public static string GET_RANDOM_GUID() => $"{Ctrls.TRIAL}/{Routes.GET_RANDOM_GUID}";
    public static string POST_GUID(Guid value) => $"{Ctrls.TRIAL}/{Routes.POST_GUID}?value={value}";


    // WeatherForecasts 
    public static string GET_WEATHERFORECASTS(int? rowCount) => $"{Ctrls.WEATERFORECASTS}?r={rowCount ?? 10}";


    // Configuration
    public static string GET_MEDIAFILES_OPTIONS() => $"{Ctrls.CONFIGURATION}/{Routes.GET_MEDIAFILES_OPTIONS}";
    public static string GET_FILEMANAGER_OPTIONS() => $"{Ctrls.CONFIGURATION}/{Routes.GET_FILEMANAGER_OPTIONS}";
    public static string GET_IMAGE_OPTIONS() => $"{Ctrls.CONFIGURATION}/{Routes.GET_IMAGE_OPTIONS}";
    public static string GET_VIDEO_OPTIONS() => $"{Ctrls.CONFIGURATION}/{Routes.GET_VIDEO_OPTIONS}";
    public static string GET_SOUND_OPTIONS() => $"{Ctrls.CONFIGURATION}/{Routes.GET_SOUND_OPTIONS}";
    public static string GET_AZURE_OPTIONS() => $"{Ctrls.CONFIGURATION}/{Routes.GET_AZURE_OPTIONS}";
    public static string GET_CORS_OPTIONS() => $"{Ctrls.CONFIGURATION}/{Routes.GET_CORS_OPTIONS}";
    public static string GET_APP_VERSIONS() => $"{Ctrls.CONFIGURATION}/{Routes.GET_APP_VERSIONS}";


    // Files
    public static string GET_FILES_LIST() => $"{Ctrls.FILES}/{Routes.GET_FILES}";
    public static string DELETE_FILE(DeleteFileRequest request) => $"{Ctrls.FILES}/{Routes.DELETE_FILE}?filename={HttpUtility.UrlEncode(request.FileName)}";
    public static string POST_FILE(string id) => $"{Ctrls.FILES}/{Routes.POST_FILE}?id={id}";
    public static string POST_FILE_STREAM() => $"{Ctrls.FILES}/{Routes.POST_FILE_STREAM}";
}
