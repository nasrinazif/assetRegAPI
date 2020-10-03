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
        [HttpGet("company/{id}")]
        public async Task<IActionResult> GetUsersByCompany(int id)
        {
            var usersByCompany = await _repo.GetUsersByCompanyAsync(id);

            foreach (var user in usersByCompany)
            {
                /* Refrences to related entities*/
                var companyCode = user.CompanyId.GetValueOrDefault();
                user.Company = _repo.GetCompany(companyCode);

                var userTypeCode = user.UserTypeId.GetValueOrDefault();
                user.UserType = _repo.GetUserType(userTypeCode);
            }

            var usersToReturn = _mapper.Map<IEnumerable<UserToReturnDto>>(usersByCompany);

            return Ok(usersToReturn);
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

        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetUserByName(string username)
        {
            var user = await _repo.GetUserByName(username);

            var userToReturn = _mapper.Map<UserToReturnDto>(user);

            return Ok(userToReturn);
        }

        [HttpDelete("user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userToDelete = _repo.GetUserSync(id);

            _repo.DeleteUser(userToDelete);

            if (await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Failed to delete the user");
        }
    }
}