﻿using Domain.Aggregates.UserProfileAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.UserProfiles.Queries
{
    public record GetUserProfileByIdQuery(Guid UserId) : IRequest<UserProfile>;
}
