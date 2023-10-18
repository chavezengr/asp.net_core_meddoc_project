using Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace ApplicationCore.Abstractions
{
    public interface IUserProfileRepository
    {
        Task<UserProfile> CreateUserProfiles(UserProfile profile);
        Task<IEnumerable<UserProfile>> GetAllUserProfiles();
        Task<UserProfile> GetUserProfileById(Guid userId);
        Task<UserProfile> UpdateUserProfile(UserProfile profile);
        Task<Unit> DeleteUserProfile(UserProfile userId);
    }
}
