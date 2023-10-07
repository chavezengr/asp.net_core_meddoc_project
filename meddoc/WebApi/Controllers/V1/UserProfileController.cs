using ApplicationCore.UserProfiles.Commands;
using ApplicationCore.UserProfiles.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts.UserProfile.Requests;
using WebApi.Contracts.UserProfile.Responses;
using WebApi.Routes;

namespace WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class UserProfileController(IMediator mediator, IMapper mapper) : Controller
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<IActionResult> CreateUserProfiles([FromBody] UserProfileRequest userProfileRequest)
        {
            var requestUserProfile = _mapper.Map<CreateUserProfileCommand>(userProfileRequest);
            var responseUserProfile = await _mediator.Send(requestUserProfile);
            var userProfile = _mapper.Map<UserProfileResponse>(responseUserProfile);

            return CreatedAtAction(nameof(GetUserProfileById), new {id = responseUserProfile.UserId}, userProfile);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserProfiles()
        {
            var requestUserProfiles = new GetAllUserProfilesQuery();
            var responseUserProfiles = await _mediator.Send(requestUserProfiles);
            var userProfiles = _mapper.Map<List<UserProfileResponse>>(responseUserProfiles);

            return (IActionResult)Task.FromResult(Ok(userProfiles));
        }

        [HttpGet]
        [Route(ApiRoutes.UserProfile.GetUserProfileById)]
        public async Task<IActionResult> GetUserProfileById(string userId)
        {
            var requestUserProfile = _mapper.Map<GetUserProfileByIdQuery>(userId);
            var responseUserProfile = await _mediator.Send(requestUserProfile);
            var userProfile = _mapper.Map<UserProfileResponse>(responseUserProfile);

            return (IActionResult)Task.FromResult(Ok(userProfile));
        }

    }
}
