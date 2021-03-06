﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NIOCAssetsRegistrationSystem.API.Data;
using NIOCAssetsRegistrationSystem.API.Dtos;
using NIOCAssetsRegistrationSystem.API.Helper;
using NIOCAssetsRegistrationSystem.API.Models;

namespace NIOCAssetsRegistrationSystem.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IAssetRegistrationRepository _repo;
        private readonly IMapper _mapper;

        public PropertiesController(IAssetRegistrationRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        [HttpGet("property/{id}", Name = "GetProperty")]
        public async Task<IActionResult> GetProperty(int id)
        {
            /* Get the property from the asset repo by its id*/
            var propertry = await _repo.GetCompaniesPropertyAsync(id);

            /* Refrences to related entities*/
            var companyCode = propertry.CompanyId.GetValueOrDefault();
            propertry.Company = _repo.GetCompany(companyCode);

            var ownerCode = propertry.OwnerId.GetValueOrDefault();
            propertry.Owner = _repo.GetOwner(ownerCode);

            var beneficiaryCode = propertry.BeneficiaryId.GetValueOrDefault();
            propertry.Beneficiary = _repo.GetBeneficiary(beneficiaryCode);

            var userCode = propertry.UserId.GetValueOrDefault();
            propertry.User = _repo.GetUserSync(userCode);

            var provinceCode = propertry.ProvinceId.GetValueOrDefault();
            propertry.Province = _repo.GetProvince(provinceCode);

            var cityCode = propertry.CityId.GetValueOrDefault();
            propertry.City = _repo.GetCity(cityCode);

            var ownershipDocumentTypeCode = propertry.OwnershipDocumentTypeId.GetValueOrDefault();
            propertry.OwnershipDocumentType = _repo.GetOwnershipDocumentType(ownershipDocumentTypeCode);

            var mapFormatCode = propertry.MapFormatId.GetValueOrDefault();
            propertry.MapFormat = _repo.GetMapFormat(mapFormatCode);

            var mapCoordinatesAccuracyCode = propertry.MapCoordinatesAccuracyId.GetValueOrDefault();
            propertry.MapCoordinatesAccuracy = _repo.GetMapCoordinatesAccuracy(mapCoordinatesAccuracyCode);

            var buildingTypeCode = propertry.BuildingTypeId.GetValueOrDefault();
            propertry.BuildingType = _repo.GetBuildingType(buildingTypeCode);

            /* Return the property*/
            var propertyToReturn = _mapper.Map<PropertyToReturnDto>(propertry);

            return Ok(propertyToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetProperties()
        {
            /* Get the properties from the asset repo */
            var properties = await _repo.GetCompaniesPropertiesAsync();

            foreach(var propertry in properties)
            {
                /* Refrences to related entities*/
                var companyCode = propertry.CompanyId.GetValueOrDefault();
                propertry.Company = _repo.GetCompany(companyCode);

                var userCode = propertry.UserId.GetValueOrDefault();
                propertry.User = _repo.GetUserSync(userCode);

                var provinceCode = propertry.ProvinceId.GetValueOrDefault();
                propertry.Province = _repo.GetProvince(provinceCode);

                var cityCode = propertry.CityId.GetValueOrDefault();
                propertry.City = _repo.GetCity(cityCode);
            }

            /* Return the properties*/
            var propertiesToReturn = _mapper.Map<IEnumerable<PropertiesToReturnDto>>(properties);

            return Ok(propertiesToReturn);
        }

        [HttpGet("company/{id}")]
        public async Task<IActionResult> GetPropertiesByCompanyId(int id)
        {
            /* Get the properties from the asset repo */
            var properties = await _repo.GetCompaniesPropertiesByCompanyAsync(id);

            foreach (var propertry in properties)
            {
                /* Refrences to related entities*/
                var companyCode = propertry.CompanyId.GetValueOrDefault();
                propertry.Company = _repo.GetCompany(companyCode);

                var userCode = propertry.UserId.GetValueOrDefault();
                propertry.User = _repo.GetUserSync(userCode);

                var provinceCode = propertry.ProvinceId.GetValueOrDefault();
                propertry.Province = _repo.GetProvince(provinceCode);

                var cityCode = propertry.CityId.GetValueOrDefault();
                propertry.City = _repo.GetCity(cityCode);
            }

            /* Return the properties*/
            var propertiesToReturn = _mapper.Map<IEnumerable<PropertiesToReturnDto>>(properties);

            return Ok(propertiesToReturn);
        }

        [HttpGet("company/all/{id}")]
        public async Task<IActionResult> GetAllPropertiesByCompanyId(int id)
        {
            /* Get the properties from the asset repo */
            var properties = await _repo.GetCompaniesPropertiesByCompanyAsync(id);

            foreach (var propertry in properties)
            {
                /* Refrences to related entities*/
                var companyCode = propertry.CompanyId.GetValueOrDefault();
                propertry.Company = _repo.GetCompany(companyCode);

                var userCode = propertry.UserId.GetValueOrDefault();
                propertry.User = _repo.GetUserSync(userCode);

                var provinceCode = propertry.ProvinceId.GetValueOrDefault();
                propertry.Province = _repo.GetProvince(provinceCode);

                var cityCode = propertry.CityId.GetValueOrDefault();
                propertry.City = _repo.GetCity(cityCode);

                var ownerCode = propertry.OwnerId.GetValueOrDefault();
                propertry.Owner = _repo.GetOwner(ownerCode);

                var beneficiaryCode = propertry.BeneficiaryId.GetValueOrDefault();
                propertry.Beneficiary = _repo.GetBeneficiary(beneficiaryCode);

                var ownershipDocTypeCode = propertry.OwnershipDocumentTypeId.GetValueOrDefault();
                propertry.OwnershipDocumentType = _repo.GetOwnershipDocumentType(ownershipDocTypeCode);

                var mapFormatCode = propertry.MapFormatId.GetValueOrDefault();
                propertry.MapFormat = _repo.GetMapFormat(mapFormatCode);

                var mapCoordinateAccuracyCode = propertry.MapCoordinatesAccuracyId.GetValueOrDefault();
                propertry.MapCoordinatesAccuracy = _repo.GetMapCoordinatesAccuracy(mapCoordinateAccuracyCode);

                var buildingTypeCode = propertry.BuildingTypeId.GetValueOrDefault();
                propertry.BuildingType = _repo.GetBuildingType(buildingTypeCode);
            }

            /* Return the properties*/
            var propertiesToReturn = _mapper.Map<IEnumerable<PropertiesAllFieldsForAdminToReturnDto>>(properties);

            return Ok(propertiesToReturn);
        }

        [HttpGet("company/all")]
        public async Task<IActionResult> GetAllProperties()
        {
            /* Get the properties from the asset repo */
            var properties = await _repo.GetCompaniesAllPropertiesAsync();

            foreach (var propertry in properties)
            {
                /* Refrences to related entities*/
                var companyCode = propertry.CompanyId.GetValueOrDefault();
                propertry.Company = _repo.GetCompany(companyCode);

                var userCode = propertry.UserId.GetValueOrDefault();
                propertry.User = _repo.GetUserSync(userCode);

                var provinceCode = propertry.ProvinceId.GetValueOrDefault();
                propertry.Province = _repo.GetProvince(provinceCode);

                var cityCode = propertry.CityId.GetValueOrDefault();
                propertry.City = _repo.GetCity(cityCode);

                var ownerCode = propertry.OwnerId.GetValueOrDefault();
                propertry.Owner = _repo.GetOwner(ownerCode);

                var beneficiaryCode = propertry.BeneficiaryId.GetValueOrDefault();
                propertry.Beneficiary = _repo.GetBeneficiary(beneficiaryCode);

                var ownershipDocTypeCode = propertry.OwnershipDocumentTypeId.GetValueOrDefault();
                propertry.OwnershipDocumentType = _repo.GetOwnershipDocumentType(ownershipDocTypeCode);

                var mapFormatCode = propertry.MapFormatId.GetValueOrDefault();
                propertry.MapFormat = _repo.GetMapFormat(mapFormatCode);

                var mapCoordinateAccuracyCode = propertry.MapCoordinatesAccuracyId.GetValueOrDefault();
                propertry.MapCoordinatesAccuracy = _repo.GetMapCoordinatesAccuracy(mapCoordinateAccuracyCode);

                var buildingTypeCode = propertry.BuildingTypeId.GetValueOrDefault();
                propertry.BuildingType = _repo.GetBuildingType(buildingTypeCode);
            }

            /* Return the properties*/
            var propertiesToReturn = _mapper.Map<IEnumerable<PropertiesAllFieldsForAdminToReturnDto>>(properties);

            return Ok(propertiesToReturn);
        }

        [HttpGet("company/{id}/paged")]
        public async Task<IActionResult> GetPagedPropertiesByCompanyId([FromQuery]UserParams userParams, int id)
        {
            var properties = await _repo.GetPagedPropertiesByCompanyAsync(userParams, id);

            foreach (var propertry in properties)
            {
                /* Refrences to related entities*/
                var companyCode = propertry.CompanyId.GetValueOrDefault();
                propertry.Company = _repo.GetCompany(companyCode);

                var userCode = propertry.UserId.GetValueOrDefault();
                propertry.User = _repo.GetUserSync(userCode);

                var provinceCode = propertry.ProvinceId.GetValueOrDefault();
                propertry.Province = _repo.GetProvince(provinceCode);

                var cityCode = propertry.CityId.GetValueOrDefault();
                propertry.City = _repo.GetCity(cityCode);
            }

            /* Return the properties*/
            var propertiesToReturn = _mapper.Map<IEnumerable<PropertiesToReturnDto>>(properties);

            Response.AddPagination(properties.CurrentPage, properties.PageSize, properties.TotalCount, properties.TotalPages);

            return Ok(propertiesToReturn);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetPropertiesByUserId(int id)
        {
            /* Get the properties from the asset repo */
            var properties = await _repo.GetCompaniesPropertiesByUserAsync(id);

            foreach (var propertry in properties)
            {
                /* Refrences to related entities*/
                var companyCode = propertry.CompanyId.GetValueOrDefault();
                propertry.Company = _repo.GetCompany(companyCode);

                var userCode = propertry.UserId.GetValueOrDefault();
                propertry.User = _repo.GetUserSync(userCode);

                var provinceCode = propertry.ProvinceId.GetValueOrDefault();
                propertry.Province = _repo.GetProvince(provinceCode);

                var cityCode = propertry.CityId.GetValueOrDefault();
                propertry.City = _repo.GetCity(cityCode);
            }

            /* Return the properties*/
            var propertiesToReturn = _mapper.Map<IEnumerable<PropertiesToReturnDto>>(properties);

            return Ok(propertiesToReturn);
        }

        [HttpGet("user/{id}/paged")]
        public async Task<IActionResult> GetPagedPropertiesByUserId([FromQuery]UserParams userParams, int id)
        {
            /* Get the properties from the asset repo */
            userParams.UserId = id;
            var properties = await _repo.GetPagedCompaniesPropertiesByUserAsync(userParams);

            foreach (var propertry in properties)
            {
                /* Refrences to related entities*/
                var companyCode = propertry.CompanyId.GetValueOrDefault();
                propertry.Company = _repo.GetCompany(companyCode);

                var userCode = propertry.UserId.GetValueOrDefault();
                propertry.User = _repo.GetUserSync(userCode);

                var provinceCode = propertry.ProvinceId.GetValueOrDefault();
                propertry.Province = _repo.GetProvince(provinceCode);

                var cityCode = propertry.CityId.GetValueOrDefault();
                propertry.City = _repo.GetCity(cityCode);
            }

            /* Return the properties*/
            var propertiesToReturn = _mapper.Map<IEnumerable<PropertiesToReturnDto>>(properties);

            Response.AddPagination(properties.CurrentPage, properties.PageSize, properties.TotalCount, properties.TotalPages);

            return Ok(propertiesToReturn);
        }

        [HttpGet("user/{id}/companycode")]
        public async Task<IActionResult> GetCompanyCodeForUser(int id)
        {
            var companyCode = await _repo.GetCompanyCodeForUser(id);

            return Ok(companyCode);
        }

        [HttpDelete("property/{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var propertyToDelete = _repo.GetCompaniesProperty(id);

            _repo.DeleteCompanyPropertyInquiry(propertyToDelete);

            if (await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Failed to delete the property");
        }

        [HttpGet("owners")]
        public async Task<IActionResult> GetOwners()
        {
            var owners = await _repo.GetOwnersAsync();

            var ownersToReturn = _mapper.Map<IEnumerable<OwnerToRetuenDto>>(owners);

            return Ok(ownersToReturn);
        }

        [HttpGet("beneficiaries")]
        public async Task<IActionResult> GetBeneficiaries()
        {
            var beneficiaries = await _repo.GetBeneficiaryAsync();

            var beneficiariesToReturn = _mapper.Map<IEnumerable<BeneficiaryToReturnDto>>(beneficiaries);

            return Ok(beneficiariesToReturn);
        }

        [HttpGet("provinces")]
        public async Task<IActionResult> GetProvinces()
        {
            var provinces = await _repo.GetProvincesAsync();

            var provincesToReturn = _mapper.Map<IEnumerable<ProvinceToReturnDto>>(provinces);

            return Ok(provincesToReturn);
        }

        [HttpGet("provinces/{id}")]
        public async Task<IActionResult> GetProvinceById(int id)
        {
            var province = await _repo.GetProvinceByIdAsync(id);

            var provinceToReturn = _mapper.Map<ProvinceToReturnDto>(province);

            return Ok(provinceToReturn);
        }

        [HttpGet("cities")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _repo.GetCitiesAsync();

            var citiesToReturn = _mapper.Map<IEnumerable<CityToReturnDto>>(cities);

            return Ok(citiesToReturn);
        }

        [HttpGet("cities/{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var city = await _repo.GetCityByIdAsync(id);

            var cityToReturn = _mapper.Map<CityToReturnDto>(city);

            return Ok(cityToReturn);
        }

        [HttpGet("province/{id}/cities")]
        public async Task<IActionResult> GetCitiesByProvinceId(int id)
        {
            var cities = await _repo.GetCitiesByProvinceIdAsync(id);

            var citiesToReturn = _mapper.Map<IEnumerable<CityToReturnDto>>(cities);

            return Ok(citiesToReturn);
        }

        [HttpGet("ownershipdocumenttypes")]
        public async Task<IActionResult> GetOwnershipDocumentTypes()
        {
            var ownershipDocumentTypes = await _repo.GetOwnershipDocumentsTypesAsync();

            var ownershipDocumentTypesToReturn = _mapper.Map<IEnumerable<OwnershipDocumentTypeToReturnDto>>(ownershipDocumentTypes);

            return Ok(ownershipDocumentTypesToReturn);
        }

        [HttpGet("ownershipdocumenttypes/{id}")]
        public async Task<IActionResult> GetOwnershipDocumentTypeById(int id)
        {
            var ownershipDocumentType = await _repo.GetOwnershipDocumentsTypeByIdAsync(id);

            var ownershipDocumentTypeToReturn = _mapper.Map<OwnershipDocumentTypeToReturnDto>(ownershipDocumentType);

            return Ok(ownershipDocumentTypeToReturn);
        }

        [HttpGet("mapformats")]
        public async Task<IActionResult> GetMapFormats()
        {
            var mapFormats = await _repo.GetMapFormatsAsync();

            var mapFormatsToReturn = _mapper.Map<IEnumerable<MapFormatToReturnDto>>(mapFormats);

            return Ok(mapFormatsToReturn);
        }

        [HttpGet("mapformats/{id}")]
        public async Task<IActionResult> GetMapFormatById(int id)
        {
            var mapFormat = await _repo.GetMapFormatByIdAsync(id);

            var mapFormatToReturn = _mapper.Map<MapFormatToReturnDto>(mapFormat);

            return Ok(mapFormatToReturn);
        }

        [HttpGet("mapcoordinatesaccuracies")]
        public async Task<IActionResult> GetMapCoordinatesAccuracies()
        {
            var mapCoordinatesAccuracies = await _repo.GetMapCoordinatesAccuraciesAsync();

            var mapCoordinatesAccuraciesToReturn = _mapper.Map<IEnumerable<MapCoordinatesAccuracyToReturnDto>>(mapCoordinatesAccuracies);

            return Ok(mapCoordinatesAccuraciesToReturn);
        }

        [HttpGet("mapcoordinatesaccuracies/{id}")]
        public async Task<IActionResult> GetMapCoordinatesAccuracyById(int id)
        {
            var mapCoordinatesAccuracy = await _repo.GetMapCoordinatesAccuracyByIdAsync(id);

            var mapCoordinatesAccuracyToReturn = _mapper.Map<MapCoordinatesAccuracyToReturnDto>(mapCoordinatesAccuracy);

            return Ok(mapCoordinatesAccuracyToReturn);
        }

        [HttpGet("buildingtypes")]
        public async Task<IActionResult> GetBuildingTypes()
        {
            var buildingTypes = await _repo.GetBuildingTypesAsync();

            var buildingTypesToReturn = _mapper.Map<IEnumerable<BuildingTypeToReturnDto>>(buildingTypes);

            return Ok(buildingTypesToReturn);
        }

        [HttpGet("buildingtypes/{id}")]
        public async Task<IActionResult> GetBuildingTypeById(int id)
        {
            var buildingType = await _repo.GetBuildingTypeByIdAsync(id);

            var buildingTypeToReturn = _mapper.Map<BuildingTypeToReturnDto>(buildingType);

            return Ok(buildingTypeToReturn);
        }

        [HttpPost("addproperty")]
        public async Task<IActionResult> CreateProperty(PropertyToRegisterDto propertyToRegisterDto)
        {
            var propertyToCreate = _mapper.Map<CompaniesPropertyInquiry>(propertyToRegisterDto);

            _repo.Add(propertyToCreate);

            if (await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Failed to save the new property");
        }

        [HttpPut("property/{id}")]
        public async Task<IActionResult> UpdateProperty(int id, PropertyToUpdateDto propertyToUpdateDto)
        {
            var propertyFromRepo = await _repo.GetCompaniesPropertyAsync(id);

            _mapper.Map(propertyToUpdateDto, propertyFromRepo);

            if (await _repo.SaveAll())
            {
                return NoContent();
            }

            throw new Exception($"Updating property {id} failed on save");
        }

        [HttpGet("companiespropcount")]
        public async Task<IActionResult> GetCompaniesPropCount()
        {
            var comPropCoun = await _repo.GetCompaniesPropertiesCount();

            return Ok(comPropCoun);
        }

        [HttpGet("recordscount/{id}")]
        public async Task<IActionResult> GetCompanyRecordCount(int id)
        {
            var comPropCoun = await _repo.GetCompanyRecordCount(id);

            return Ok(comPropCoun);
        }

        [HttpPost("addcity")]
        public async Task<IActionResult> CreateCity(CityToRegister cityToRegister)
        {
            var cityToCreate = _mapper.Map<City>(cityToRegister);

            _repo.Add(cityToCreate);

            if (await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Failed to save the new city");
        }
    }    
}
