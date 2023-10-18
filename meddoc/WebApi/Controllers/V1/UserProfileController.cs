using ApplicationCore.UserProfiles.Commands;
using ApplicationCore.UserProfiles.Queries;
using AutoMapper;
using Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
            var userProfileCommand = _mapper.Map<CreateUserProfileCommand>(userProfileRequest);
            var userProfile = await _mediator.Send(userProfileCommand);
            var userProfileResponse = _mapper.Map<UserProfileResponse>(userProfile);

            return CreatedAtAction(nameof(GetUserProfileById), new {id = userProfile.UserId}, userProfileResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserProfiles()
        {
            var userProfilesQuery = new GetAllUserProfilesQuery();
            var userProfiles = await _mediator.Send(userProfilesQuery);
            var userProfilesResponse = _mapper.Map<List<UserProfileResponse>>(userProfiles);

            return Ok(userProfilesResponse);
        }

        [HttpGet]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> GetUserProfileById(string id)
        {
            var userProfileByIdQuery = _mapper.Map<GetUserProfileByIdQuery>(Guid.Parse(id));
            var userProfile = await _mediator.Send(userProfileByIdQuery);
            var userProfileResponse = _mapper.Map<UserProfileResponse>(userProfile);

            return Ok(userProfileResponse);
        }

        [HttpPut]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> UpdateUserProfile(string id, UserProfileRequest userProfileRequest)
        {
            var userBasicInfoCommand = _mapper.Map<UpdateUserBasicInfoCommand>(userProfileRequest);
            userBasicInfoCommand.UserId = Guid.Parse(id);
            var userProfile = await _mediator.Send(userBasicInfoCommand);
            var userProfileResponse = _mapper.Map<UserProfileResponse>(userProfile);

            return Ok(userProfileResponse);
        }

        [HttpDelete]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> DeleteUserProfile(string id)
        {
            var userProfileCommand = new DeleteUserProfileCommand() { UserId = Guid.Parse(id) };
            await _mediator.Send(userProfileCommand);

            return NoContent();
        }
    }
}
