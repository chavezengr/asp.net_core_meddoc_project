using ApplicationCore.Abstractions;
using ApplicationCore.Posts.CommandHandlers;
using ApplicationCore.UserProfiles.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.UserProfiles.CommandHandlers
{
    public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand, Unit>
    {
        private readonly IUserProfileRepository _repository;

        public DeleteUserProfileCommandHandler(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _repository.GetUserProfileById(request.UserId);

            var deletedProfile = await _repository.DeleteUserProfile(userProfile);

            return deletedProfile;
        }
    }
}
