using ApplicationCore.Abstractions;
using ApplicationCore.Posts.Commands;
using Domain.Aggregates.PostAggregate;
using MediatR;

namespace ApplicationCore.Posts.CommandHandlers
{
    public class UpdatePostHandler(IPostRepository postRepository) : IRequestHandler<UpdatePost, Post>
    {
        private readonly IPostRepository _postRepository = postRepository;

        public async Task<Post> Handle(UpdatePost request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.UpdatePost(request.PostContent, request.PostId);

            return post;
        }
    }
}
