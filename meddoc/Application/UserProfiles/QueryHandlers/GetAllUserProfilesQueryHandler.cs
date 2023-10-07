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
    public class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfilesQuery, IEnumerable<UserProfile>>
    {
        private readonly IUserProfileRepository _userProfile;

        public GetAllUserProfilesQueryHandler(IUserProfileRepository userProfile)
        {
            _userProfile = userProfile;
        }

        public async Task<IEnumerable<UserProfile>> Handle(GetAllUserProfilesQuery request, CancellationToken cancellationToken)
        {
           return await _userProfile.GetAllUserProfiles();
        }
    }
}
