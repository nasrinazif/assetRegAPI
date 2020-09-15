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
    }
}