using ApplicationCore.Abstractions;
using ApplicationCore.Posts.Commands;
using Domain.Aggregates.PostAggregate;
using MediatR;

namespace ApplicationCore.Posts.CommandHandlers
{
    public class CreatePostHandler(IPostRepository postRepository) : IRequestHandler<CreatePost, Post>
    {
        private readonly IPostRepository _postRepository = postRepository;

        public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
        {
            var requestInfo = Post.CreatePost(request.UserProfileId, request.TextContent);

            return await _postRepository.CreatePost(requestInfo);
        }
    }
}
