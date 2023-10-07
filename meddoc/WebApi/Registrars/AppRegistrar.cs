using ApplicationCore;
using MediatR;
using WebApi.Registrars.Abstractions;

namespace WebApi.Registrars
{
    public class AppRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Program), typeof(ApplicationCoreStart));
            builder.Services.AddMediatR(typeof(ApplicationCoreStart));
        }
    }
}
