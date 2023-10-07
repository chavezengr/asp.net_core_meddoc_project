using MinimalWebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Extension method
builder.RegisterServices();

var app = builder.Build();

app.Use(async (ctx, next) =>
{
    try
    {
        ctx.Response.StatusCode = 200;
        await next();
    } 
    catch(Exception) {
        ctx.Response.StatusCode = 500;
        await ctx.Response.WriteAsync(text: "An error occurred!");
    }
});

app.UseHttpsRedirection();

// Add Endpoint definition method
app.RegisterEndpointDefinitions();

app.Run();
