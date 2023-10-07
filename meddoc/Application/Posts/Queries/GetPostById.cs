using Domain.Aggregates.PostAggregate;
using MediatR;

namespace ApplicationCore.Posts.Queries
{
    public record GetPostById(Guid PostId) : IRequest<Post>;
}
