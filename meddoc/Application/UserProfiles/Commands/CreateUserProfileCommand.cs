using Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace ApplicationCore.UserProfiles.Commands
{
    public class CreateUserProfileCommand() : IRequest<UserProfile>
    {
        public BasicInfo BasicInfo { get; set; }
    }
}
