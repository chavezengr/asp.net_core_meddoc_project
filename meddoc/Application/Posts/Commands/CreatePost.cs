using Domain.Aggregates.PostAggregate;
using MediatR;

namespace ApplicationCore.Posts.Commands
{
    public class CreatePost : IRequest<Post>
    {
        public Guid UserProfileId { get; set; }
        public string? TextContent { get; set; }
    }
}
