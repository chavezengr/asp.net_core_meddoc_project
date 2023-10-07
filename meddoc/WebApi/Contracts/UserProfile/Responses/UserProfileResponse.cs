using Domain.Aggregates.UserProfileAggregate;

namespace WebApi.Contracts.UserProfile.Responses
{
    public record UserProfileResponse
    {
        public Guid UserId { get; set; }
        public string IdentityId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public BasicInfoResponse BasicInfo { get; set; }
    }
}
