using ApplicationCore.Abstractions;
using ApplicationCore.Posts.Queries;
using Domain.Aggregates.PostAggregate;
using MediatR;

namespace ApplicationCore.Posts.QueryHandlers
{
    public class GetPostByIdHandler(IPostRepository repository) : IRequestHandler<GetPostById, Post>
    {
        private readonly IPostRepository _repository = repository;

        public async Task<Post> Handle(GetPostById request, CancellationToken cancellationToken)
        {
            var post = await _repository.GetPostById(request.PostId);

            return post;
        }
    }
}
