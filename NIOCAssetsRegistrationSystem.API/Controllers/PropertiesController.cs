using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NIOCAssetsRegistrationSystem.API.Data;
using NIOCAssetsRegistrationSystem.API.Dtos;
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
    }    
}
