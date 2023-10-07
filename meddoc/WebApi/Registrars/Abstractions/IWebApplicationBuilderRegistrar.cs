namespace WebApi.Registrars.Abstractions
{
    public interface IWebApplicationBuilderRegistrar
    {
        void RegisterServices(WebApplicationBuilder builder);
    }
}
