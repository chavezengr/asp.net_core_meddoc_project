
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using WebApi.Middleware;
using WebApi.Registrars.Abstractions;

namespace WebApi.Registrars
{
    public class MvcWebAppRegistrar : IWebApplicationRegistrar
    {
        public void RegisterPipelineComponents(WebApplication app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.ApiVersion.ToString());
                }
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            app.MapControllers();
        }
    }
}
