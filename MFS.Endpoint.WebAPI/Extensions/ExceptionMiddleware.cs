using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MFS.Endpoint.WebAPI.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string result;

            if (exception is UnauthorizedAccessException)
            {
                result = JsonSerializer.Serialize(new ErrorDetails(
                    context.Response.StatusCode,
                    "Unauthorized Access!",
                    exception.StackTrace
                ));
            }
            else if (context.Response.StatusCode == 403)
            {
                result = JsonSerializer.Serialize(new ErrorDetails(
                    context.Response.StatusCode,
                    "Limited Access!",
                    exception.StackTrace
                ));
            }
            //else if (exception is DbUpdateException && exception.InnerException.Message.Contains("DELETE statement conflicted"))
            //{
            //    result = JsonSerializer.Serialize(new ErrorDetails(
            //        context.Response.StatusCode,
            //        "DELETE statement conflicted!",
            //        exception.StackTrace
            //    ));
            //}
            else
            {
                result = JsonSerializer.Serialize(new ErrorDetails(
                    context.Response.StatusCode,
                    exception.GetBaseException().Message,
                    exception.StackTrace
                ));
            }
            return context.Response.WriteAsync(result);
        }
    }
}
