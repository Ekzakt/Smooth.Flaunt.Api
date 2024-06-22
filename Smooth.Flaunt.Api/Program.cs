using Ekzakt.EmailSender.Smtp.Configuration;
using Ekzakt.FileManager.AzureBlob.Configuration;
using Smooth.Flaunt.Api.Application.Configuration;
using Smooth.Flaunt.Api.Application.WeatherForecasts;
using Smooth.Flaunt.Api.Configuration;
using Smooth.Flaunt.Api.Hubs;
using Smooth.Flaunt.Api.Infrastructure.Configuration;
using Smooth.Flaunt.Api.Infrastructure.WeatherForecasts;
using Smooth.Shared.Configurations.Options;
using Smooth.Shared.Endpoints;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//builder.Host.UseSerilog((context, configuration) =>
//    configuration.ReadFrom.Configuration(context.Configuration));

//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Console()
//    .CreateBootstrapLogger();

builder.AddSwaggerGen();
builder.AddResponseSizeCompression();
builder.AddConfigurationOptions();
builder.AddAzureClientServices();
builder.AddAzureKeyVault();
//builder.AddAuthentication();
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
//app.UseAuthentication();
//app.UseAuthorization();
app.MapControllers();
app.MapHub<NotificationsHub>(Hubs.NOTIFICATIONS_HUB);
app.MapHub<ProgressHub>(Hubs.PROGRESS_HUB);

app.Run();
