using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using my_book.Data.ViewModels;
using System.Net;

namespace my_book.Exceptions
{
    public static class ExceptionMiddlewareExtentions
    {
        public static void ConfigureBuildInExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context => 
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var contextRequest = context.Features.Get<IHttpRequestFeature>();

                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorVM()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Path = contextRequest.Path
                        }.ToString());
                    }
                });
            });
        }

        public static void ConfigureCustomBuildInExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }

    }
}
