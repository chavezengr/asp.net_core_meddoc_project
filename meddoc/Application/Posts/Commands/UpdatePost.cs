using Domain.Aggregates.PostAggregate;
using MediatR;

namespace ApplicationCore.Posts.Commands
{
    public class UpdatePost : IRequest<Post>
    {
        public string? PostContent { get; set; }
        public Guid PostId { get; set; }
        public Guid UserProfileId { get; set; }
    }
}
