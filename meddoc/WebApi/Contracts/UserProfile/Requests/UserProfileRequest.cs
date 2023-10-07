using Domain.Aggregates.UserProfileAggregate;

namespace WebApi.Contracts.UserProfile.Requests
{
    public record UserProfileRequest
    {
        public BasicInfoRequest BasicInfo { get; set; }
    }
}
