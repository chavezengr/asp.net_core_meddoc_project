using ApplicationCore.UserProfiles.Commands;
using AutoMapper;
using Domain.Aggregates.UserProfileAggregate;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts.UserProfile.Requests;
using WebApi.Contracts.UserProfile.Responses;
using WebApi.Routes;

namespace WebApi.MappingProfiles
{
    public class UserProfileMappings : Profile
    {
        public UserProfileMappings()
        {
            CreateMap<UserProfileRequest, CreateUserProfileCommand>();
            CreateMap<UserProfile, UserProfileResponse>();
            CreateMap<BasicInfo, BasicInfoResponse>();
        }
    }
}
