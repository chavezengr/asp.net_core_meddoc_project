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
            CreateMap<UserProfileRequest, CreateUserProfileCommand>()
                .ForMember(upc => upc.BasicInfo, src => src.MapFrom(upr => upr.BasicInfo));
            CreateMap<UserProfileRequest, UpdateUserBasicInfoCommand>();

            CreateMap<UserProfile, UserProfileResponse>()
                .ForMember(upr => upr.BasicInfo, src => src.MapFrom(up => up.BasicInfo));
            CreateMap<UserProfile, UserProfileRequest>()
                .ForMember(upr => upr.BasicInfo, src => src.MapFrom(up => up.BasicInfo));

            CreateMap<BasicInfo, BasicInfoResponse>().ReverseMap();
            CreateMap<BasicInfo, BasicInfoRequest>().ReverseMap();

        }
    }
}
