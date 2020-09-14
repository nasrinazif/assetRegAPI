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
            //CreateMap<UserForRegisterDto, User>()
            //    .ForMember(dest => dest.Company, opt =>
            //    opt.MapFrom(src => src));
            CreateMap<User, UserToReturnDto>()
                .ForMember(dest => dest.CompanyName, opt => 
                opt.MapFrom(src => src.Company.Name.ToString()))
                .ForMember(dest => dest.UserTypeName, opt =>
                opt.MapFrom(src => src.UserType.Name));
        }
    }
}
