using ApplicationCore.Abstractions;
using Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserProfileRepository(DataContext context) : IUserProfileRepository
    {
        protected readonly DataContext _context = context;

        public async Task<UserProfile> CreateUserProfiles(UserProfile profile)
        {
            _context.UserProfiles.Add(profile);
            await _context.SaveChangesAsync();

            return profile;
        }

        public async Task<IEnumerable<UserProfile>> GetAllUserProfiles()
        {
            return await _context.UserProfiles.AsNoTracking().ToListAsync();
        }

        public async Task<UserProfile> GetUserProfileById(Guid userId)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(up => up.UserId == userId);

            return userProfile ?? throw new FileNotFoundException("No Data Found!");
        }

        public async Task<UserProfile> UpdateUserProfile(UserProfile profile)
        {
            _context.UserProfiles.Update(profile);
            await _context.SaveChangesAsync();

            return profile;
        }

        public async Task<Unit> DeleteUserProfile(UserProfile profile)
        {
            _context.UserProfiles.Remove(profile);
            await _context.SaveChangesAsync();

            return new Unit();
        }
    }
}
