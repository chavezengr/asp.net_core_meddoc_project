using Domain.Aggregates.UserProfileAggregate;

namespace ApplicationCore.Abstractions
{
    public interface IUserProfileRepository
    {
        Task<UserProfile> CreateUserProfiles(UserProfile profile);
        Task<IEnumerable<UserProfile>> GetAllUserProfiles();
        Task<UserProfile> GetUserProfileById(Guid userId);
    }
}
