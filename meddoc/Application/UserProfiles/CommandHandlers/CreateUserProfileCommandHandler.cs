using ApplicationCore.Abstractions;
using ApplicationCore.UserProfiles.Commands;
using AutoMapper;
using Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace ApplicationCore.UserProfiles.CommandHandlers
{
    internal sealed class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, UserProfile>
    {
        private readonly IUserProfileRepository _userProfile;

        public CreateUserProfileCommandHandler(IUserProfileRepository userProfile)
        {
            _userProfile = userProfile; 
        }

        public async Task<UserProfile> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var requestInfo = request.BasicInfo;
            var basicInfo = BasicInfo.CreateBasicInfo(requestInfo.FirstName, requestInfo.LastName,
                requestInfo.EmailAddress, requestInfo.PhoneNumber, requestInfo.DateOfBirth, requestInfo.CurrentCity);
            var createdProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), basicInfo);

            return await _userProfile.CreateUserProfiles(createdProfile);
        }
    }
}
