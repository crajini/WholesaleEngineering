using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Models;
using System.Net;

namespace WholesaleEngineering
{
    public static class MiddlewareExceptionHandler
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        //logging of exception on the file
                        loggerFactory.CreateLogger("GlobalException").LogError($"Something went wrong: {contextFeature.Error}");
                        //Response to the client
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }
    }
}
