using MediatR;

namespace ApplicationCore.Posts.Commands
{
    public class DeletePost : IRequest
    {
        public Guid PostId { get; set; }
    }
}
