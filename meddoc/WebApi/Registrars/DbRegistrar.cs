


using DataAccess;
using Microsoft.EntityFrameworkCore;
using WebApi.Registrars.Abstractions;

namespace WebApi.Registrars
{
    public class DbRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            var cs = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(cs));
        }
    }
}
