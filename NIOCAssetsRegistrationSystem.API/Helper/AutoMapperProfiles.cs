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
            CreateMap<UserForUpdateDto, User>();
            CreateMap<UserForChangePasswordDto, User>();
            CreateMap<User, UserToReturnDto>()
                .ForMember(dest => dest.CompanyName, opt => 
                opt.MapFrom(src => src.Company.Name.ToString()))
                .ForMember(dest => dest.UserTypeName, opt =>
                opt.MapFrom(src => src.UserType.Name.ToString()));
            CreateMap<CompaniesPropertyInquiry, PropertyToReturnDto>()
                .ForMember(dest => dest.CompanyName, opt =>
                opt.MapFrom(src => src.Company.Name.ToString()))
                .ForMember(dest => dest.UserName, opt =>
                opt.MapFrom(src => src.User.UserName.ToString()))
                .ForMember(dest => dest.ProvinceName, opt =>
                opt.MapFrom(src => src.Province.Name.ToString()))
                .ForMember(dest => dest.CityName, opt =>
                opt.MapFrom(src => src.City.Name.ToString()))
                .ForMember(dest => dest.OwnershipDocumentTypeName, opt =>
                opt.MapFrom(src => src.OwnershipDocumentType.Name.ToString()))
                .ForMember(dest => dest.MapFormatName, opt =>
                opt.MapFrom(src => src.MapFormat.Name.ToString()))
                .ForMember(dest => dest.MapCoordinatesAccuracyName, opt =>
                opt.MapFrom(src => src.MapCoordinatesAccuracy.Name.ToString()))
                .ForMember(dest => dest.BuildingTypeName, opt =>
                opt.MapFrom(src => src.BuildingType.Name.ToString()))
                .ForMember(dest => dest.OwnerName, opt =>
                opt.MapFrom(src => src.Owner.Name.ToString()))
                .ForMember(dest => dest.BeneficiaryName, opt =>
                opt.MapFrom(src => src.Beneficiary.Name.ToString()));
            CreateMap<CompaniesPropertyInquiry, PropertiesToReturnDto>()
               .ForMember(dest => dest.CompanyName, opt =>
               opt.MapFrom(src => src.Company.Name.ToString()))
               .ForMember(dest => dest.UserName, opt =>
               opt.MapFrom(src => src.User.UserName.ToString()))
               .ForMember(dest => dest.ProvinceName, opt =>
               opt.MapFrom(src => src.Province.Name.ToString()))
               .ForMember(dest => dest.CityName, opt =>
               opt.MapFrom(src => src.City.Name.ToString()));
            CreateMap<Province, ProvinceToReturnDto>();
            CreateMap<City, CityToReturnDto>();
            CreateMap<OwnershipDocumentType, OwnershipDocumentTypeToReturnDto>();
            CreateMap<MapFormat, MapFormatToReturnDto>();
            CreateMap<MapCoordinatesAccuracy, MapCoordinatesAccuracyToReturnDto>();
            CreateMap<BuildingType, BuildingTypeToReturnDto>();
            CreateMap<PropertyToRegisterDto, CompaniesPropertyInquiry>();
            CreateMap<PropertyToUpdateDto, CompaniesPropertyInquiry>();
            CreateMap<Company, CompanyToReturnDto>();
            CreateMap<Owner, OwnerToRetuenDto>();
            CreateMap<Beneficiary, BeneficiaryToReturnDto>();
            CreateMap<UserType, UserTypeToReturnDto>();
            CreateMap<Confirmation, ConfirmationToReturnDto>()
                .ForMember(dest => dest.CompanyName, opt =>
                opt.MapFrom(src => src.Company.Name.ToString()))
                .ForMember(dest => dest.UserName, opt =>
                opt.MapFrom(src => src.User.UserName.ToString()));
            CreateMap<ConfirmationToCreateDto, Confirmation>();
            CreateMap<ConfirmationToUpdateDto, Confirmation>();
            CreateMap<FileUpload, UploadedFileToReturnDto>()
                .ForMember(dest => dest.CompanyName, opt =>
                opt.MapFrom(src => src.Company.Name.ToString()))
                .ForMember(dest => dest.UserName, opt =>
                opt.MapFrom(src => src.User.UserName.ToString()));
        }
    }
}
