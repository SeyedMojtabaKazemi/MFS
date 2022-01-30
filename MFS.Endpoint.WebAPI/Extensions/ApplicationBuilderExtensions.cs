using MFS.Application.Services.Commands.MerchantAggregate;
using MFS.Contract;
using MFS.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace MFS.Endpoint.WebAPI.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void CustomExcpetionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
