


using ApplicationCore.Abstractions;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using WebApi.Middleware;
using WebApi.Registrars.Abstractions;

namespace WebApi.Registrars
{
    public class DbRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            var cs = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(cs));
            builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();

            builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
        }
    }
}
