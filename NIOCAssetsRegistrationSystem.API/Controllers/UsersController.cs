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
    public class UsersController : ControllerBase
    {
        private readonly IAssetRegistrationRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IAssetRegistrationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);

            var userToReturn = _mapper.Map<UserToReturnDto>(user);

            return Ok(userToReturn);
        }

        [HttpGet("companies")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _repo.GetCompaniesAsync();

            var companiesToReturn = _mapper.Map<IEnumerable<CompanyToReturnDto>>(companies);

            return Ok(companiesToReturn);
        }

        [HttpGet("usertypes")]
        public async Task<IActionResult> GetUserTypess()
        {
            var userTypes = await _repo.GetUserTypesAsync();

            var userTypesToReturn = _mapper.Map<IEnumerable<UserTypeToReturnDto>>(userTypes);

            return Ok(userTypesToReturn);
        }

        [HttpGet("usertypesminusadmin")]
        public async Task<IActionResult> GetUserTypesMinusAdmin()
        {
            var userTypes = await _repo.GetUserTypesMinusAdminAsync();

            var userTypesToReturn = _mapper.Map<IEnumerable<UserTypeToReturnDto>>(userTypes);

            return Ok(userTypesToReturn);
        }
    }
}