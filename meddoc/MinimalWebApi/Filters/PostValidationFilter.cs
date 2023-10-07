
using Domain.Aggregates.PostAggregate;
using Microsoft.IdentityModel.Tokens;

namespace MinimalWebApi.Filters
{
    public class PostValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var post = context.GetArgument<Post>(1);

            if (post.TextContent.IsNullOrEmpty())
            {
                return await Task.FromResult(Results.BadRequest("Post not valid!"));
            }

            return await next(context);
        }
    }
}
