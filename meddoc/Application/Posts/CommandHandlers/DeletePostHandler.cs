using ApplicationCore.Abstractions;
using ApplicationCore.Posts.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Posts.CommandHandlers
{
    public class DeletePostHandler(IPostRepository postRepository) : IRequestHandler<DeletePost>
    {
        private readonly IPostRepository _postRepository = postRepository;

        public async Task<Unit> Handle(DeletePost request, CancellationToken cancellationToken)
        {
            await _postRepository.DeletePost(request.PostId);

            return Unit.Value;
        }
    }
}
