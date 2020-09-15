using AutoMapper;
using NIOCAssetsRegistrationSystem.API.Dtos;
using NIOCAssetsRegistrationSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Helper
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserForRegisterDto, User>();
            CreateMap<User, UserToReturnDto>()
                .ForMember(dest => dest.CompanyName, opt => 
                opt.MapFrom(src => src.Company.Name.ToString()))
                .ForMember(dest => dest.UserTypeName, opt =>
                opt.MapFrom(src => src.UserType.Name.ToString()));
            CreateMap<CompaniesPropertyInquiry, PropertyToReturnDto>()
                .ForMember(dest => dest.CompanyName, opt =>
                opt.MapFrom(src => src.Company.Name.ToString()))
                .ForMember(dest => dest.UserName, opt =>
                opt.MapFrom(src => src.User.UserName.ToString()));
        }
    }
}
