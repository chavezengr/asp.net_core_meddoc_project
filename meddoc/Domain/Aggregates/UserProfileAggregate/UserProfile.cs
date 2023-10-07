using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.UserProfileAggregate
{
    public class UserProfile
    {
        private UserProfile() { }

        public Guid UserId { get; private set; }
        public string IdentityId { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateUpdated { get; private set; }

        public BasicInfo BasicInfo { get; private set; }

        // Factory methods
        public static UserProfile CreateUserProfile(string identityId, BasicInfo basicInfo)
        {
            return new UserProfile
            {
                IdentityId = identityId,
                BasicInfo = basicInfo,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
            };
        }

        // Public methods
        public void UpdateBasicInfo(BasicInfo newBasicInfo)
        {
            BasicInfo = newBasicInfo;
            DateUpdated = DateTime.UtcNow;
        }
    }
}
