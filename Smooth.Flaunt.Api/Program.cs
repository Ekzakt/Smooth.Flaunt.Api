using Ekzakt.EmailSender.Smtp.Configuration;
using Ekzakt.FileManager.AzureBlob.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Smooth.Flaunt.Api.Application.Configuration;
using Smooth.Flaunt.Api.Application.WeatherForecasts;
using Smooth.Flaunt.Api.Configuration;
using Smooth.Flaunt.Api.Hubs;
using Smooth.Flaunt.Api.Infrastructure.Configuration;
using Smooth.Flaunt.Api.Infrastructure.WeatherForecasts;
using Smooth.Flaunt.Shared.Configurations.Options;
using Smooth.Flaunt.Shared.Endpoints;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//builder.Host.UseSerilog((context, configuration) =>
//    configuration.ReadFrom.Configuration(context.Configuration));

//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Console()
//    .CreateBootstrapLogger();


// Begin EJ
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // base-address of your identityserver
        options.Authority = "https://localhost:5001";
        options.Audience = "flauntapi";

        // audience is optional, make sure you read the following paragraphs
        // to understand your options
        options.TokenValidationParameters.ValidateAudience = false;

        // it's recommended to check the type header to avoid "JWT confusion" attacks
        options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };

    });
builder.Services.AddAuthorization();
// End EJ

builder.AddSwaggerGen();
builder.AddResponseSizeCompression();
builder.AddConfigurationOptions();
builder.AddAzureClientServices();
builder.AddAzureKeyVault();



builder.AddCors();
builder.AddAzureSignalR();
//builder.AddApplicationInsights();

//builder.Services.AddOpenTelemetry().UseAzureMonitor();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEkzaktEmailSenderSmtp(EkzaktEmailSenderSmtpOptions.OptionsName);
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<IConfigurationService, ConfigurationService>();
builder.Services.AddEkzaktFileManagerAzure();

var app = builder.Build();

app.UseSwaggerGen();
app.UseMiddleware<CorrelationIdMiddleware>();
app.UseCors(CorsOptions.POLICY_NAME);
app.UseHttpsRedirection();
app.UseRouting();
app.UseResponseSizeCompression();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers()
   .RequireAuthorization();

app.MapHub<NotificationsHub>(Hubs.NOTIFICATIONS_HUB);
app.MapHub<ProgressHub>(Hubs.PROGRESS_HUB);

app.Run();
