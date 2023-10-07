namespace WebApi.Registrars.Abstractions
{
    public interface IWebApplicationRegistrar
    {
        void RegisterPipelineComponents(WebApplication app);
    }
}
