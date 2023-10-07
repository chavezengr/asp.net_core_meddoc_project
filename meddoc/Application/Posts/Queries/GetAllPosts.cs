
using Domain.Aggregates.PostAggregate;
using MediatR;

namespace ApplicationCore.Posts.Queries
{
    public record GetAllPosts() : IRequest<ICollection<Post>>;
}
