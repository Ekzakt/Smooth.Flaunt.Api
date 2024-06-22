using Microsoft.Extensions.Primitives;
using Serilog.Context;

namespace Smooth.Flaunt.Api.Configuration
{
    public class CorrelationIdMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.Headers.TryGetValue("X-Correlation-Id", out StringValues correlationIds);
            var correlationId = correlationIds.FirstOrDefault() ?? Guid.NewGuid().ToString();

            using (LogContext.PushProperty("Correlation-Id", correlationId))
            { 
                await next(context);
            }
        }
    }
}
