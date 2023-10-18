using ApplicationCore.Abstractions;
using ApplicationCore.Common;
using ApplicationCore.Enums;
using ApplicationCore.Models;
using ApplicationCore.Posts.CommandHandlers;
using ApplicationCore.UserProfiles.Commands;
using Domain.Aggregates.PostAggregate;
using Domain.Aggregates.UserProfileAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.UserProfiles.CommandHandlers
{
    public class UpdateUserBasicInfoCommandHandler : IRequestHandler<UpdateUserBasicInfoCommand, GenericOperationResult<UserProfile>>
    {
        private readonly IUserProfileRepository _userProfile;
        private readonly GenericOperationResult<UserProfile> _result;

        public UpdateUserBasicInfoCommandHandler(IUserProfileRepository userProfile)
        {
            _userProfile = userProfile;
            _result = new GenericOperationResult<UserProfile>();
        }

        public async Task<GenericOperationResult<UserProfile>> Handle(UpdateUserBasicInfoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var updatedProfile = await _userProfile.GetUserProfileById(request.UserId);

                if (updatedProfile is not null)
                {
                    var requestInfo = request.BasicInfo;
                    var basicInfo = BasicInfo.CreateBasicInfo(requestInfo.FirstName, requestInfo.LastName,
                    requestInfo.EmailAddress, requestInfo.PhoneNumber, requestInfo.DateOfBirth, requestInfo.CurrentCity);
                    updatedProfile.UpdateBasicInfo(basicInfo);
                    await _userProfile.UpdateUserProfile(updatedProfile);

                    _result.Payload = updatedProfile;
                }
                else
                {
                    _result.IsError = true;
                    _result.AddError(ErrorCode.NotFound, ErrorMessage.NotFound);
                }
            }
            catch (Exception ex)
            {
                _result.IsError = true;
                _result.AddUnknownError(ex.Message);
            }

            return _result;
        }
    }
}
