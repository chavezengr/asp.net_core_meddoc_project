using ApplicationCore.Abstractions;
using ApplicationCore.Posts.CommandHandlers;
using ApplicationCore.UserProfiles.Queries;
using Domain.Aggregates.UserProfileAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.UserProfiles.QueryHandlers
{
    public class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, UserProfile>
    {
        private readonly IUserProfileRepository _userProfile;

        public GetUserProfileByIdQueryHandler(IUserProfileRepository userProfile)
        {
            _userProfile = userProfile;
        }

        public async Task<UserProfile> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userProfile.GetUserProfileById(request.UserId);
        }
    }
}
