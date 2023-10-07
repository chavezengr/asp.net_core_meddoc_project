
using ApplicationCore.Abstractions;
using ApplicationCore.Posts.Queries;
using Domain.Aggregates.PostAggregate;
using MediatR;
namespace ApplicationCore.Posts.QueryHandlers
{
    public class GetAllPostsHandler : IRequestHandler<GetAllPosts, ICollection<Post>>
    {
        private readonly IPostRepository _repository;

        public GetAllPostsHandler(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<Post>> Handle(GetAllPosts request, CancellationToken cancellationToken)
        {
           return await _repository.GetAllPosts();
        }
    }
}
