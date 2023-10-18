using ApplicationCore.Models;
using Domain.Aggregates.UserProfileAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.UserProfiles.Commands
{
    public class UpdateUserBasicInfoCommand : IRequest <GenericOperationResult<UserProfile>>
    {
        public Guid UserId { get; set; }
        public BasicInfo BasicInfo { get; set; }
    }
}
