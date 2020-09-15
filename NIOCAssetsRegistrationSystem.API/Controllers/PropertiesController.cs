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

        [HttpGet("{id}", Name = "GetProperty")]
        public async Task<IActionResult> GetProperty(int id)
        {
            var propertry = await _repo.GetCompaniesPropertyAsync(id);

            /* Refrences to related entities*/
            var companyCode = propertry.CompanyId.GetValueOrDefault();
            propertry.Company = _repo.GetCompany(companyCode);

            var userCode = propertry.UserId.GetValueOrDefault();
            propertry.User = _repo.GetUserSync(userCode);

            var propertyToReturn = _mapper.Map<PropertyToReturnDto>(propertry);

            return Ok(propertyToReturn);
        }
    }
}