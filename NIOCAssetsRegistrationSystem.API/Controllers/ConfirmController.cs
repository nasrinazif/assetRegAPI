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
    public class ConfirmController : ControllerBase
    {
        private readonly IAssetRegistrationRepository _repo;
        private readonly IMapper _mapper;

        public ConfirmController(IAssetRegistrationRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        [HttpGet("confirmation/{id}", Name = "GetConfirmation")]
        public async Task<IActionResult> GetConfirmation(int id)
        {
            var confirmation = await _repo.GetConfirmation(id);

            /* Refrences to related entities*/
            var companyCode = confirmation.CompanyId.GetValueOrDefault();
            confirmation.Company = _repo.GetCompany(companyCode);

            var userCode = confirmation.UserId.GetValueOrDefault();
            confirmation.User = _repo.GetUserSync(userCode);

            /* Return the property*/
            var confirmationToReturn = _mapper.Map<ConfirmationToReturnDto>(confirmation);

            return Ok(confirmation);
        }
}