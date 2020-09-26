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

            /* Return the confirmation*/
            var confirmationToReturn = _mapper.Map<ConfirmationToReturnDto>(confirmation);

            return Ok(confirmationToReturn);
        }

        [HttpGet("confirmations")]
        public async Task<IActionResult> GetConfirmations()
        {
            var confirmations = await _repo.GetConfirmations();

            /* Refrences to related entities*/

            foreach (var confirmation in confirmations)
            {
                var companyCode = confirmation.CompanyId.GetValueOrDefault();
                confirmation.Company = _repo.GetCompany(companyCode);

                var userCode = confirmation.UserId.GetValueOrDefault();
                confirmation.User = _repo.GetUserSync(userCode);
            }

            /* Return the confirmations*/
            var confirmationsToReturn = _mapper.Map<IEnumerable<ConfirmationToReturnDto>>(confirmations);

            return Ok(confirmationsToReturn);
        }

        [HttpGet("confirmations/company/{id}")]
        public async Task<IActionResult> GetConfirmationsByCompany(int id)
        {
            var confirmations = await _repo.GetConfirmationByCompanyId(id);

            /* Refrences to related entities*/

            foreach (var confirmation in confirmations)
            {
                var companyCode = confirmation.CompanyId.GetValueOrDefault();
                confirmation.Company = _repo.GetCompany(companyCode);

                var userCode = confirmation.UserId.GetValueOrDefault();
                confirmation.User = _repo.GetUserSync(userCode);
            }

            /* Return the confirmations*/
            var confirmationsToReturn = _mapper.Map<IEnumerable<ConfirmationToReturnDto>>(confirmations);

            return Ok(confirmationsToReturn);
        }

        [HttpGet("latestconfirmation/company/{id}")]
        public async Task<IActionResult> GetLatestConfirmationByCompany(int id)
        {
            var confirmation = await _repo.GetLatestConfirmationByCompany(id);

            /* Refrences to related entities*/

            if(confirmation != null)
            {
                var companyCode = confirmation.CompanyId.GetValueOrDefault();
                confirmation.Company = _repo.GetCompany(companyCode);

                var userCode = confirmation.UserId.GetValueOrDefault();
                confirmation.User = _repo.GetUserSync(userCode);
            }   

            /* Return the confirmations*/
            var confirmationToReturn = _mapper.Map<ConfirmationToReturnDto>(confirmation);

            return Ok(confirmationToReturn);
        }

        [HttpPost("addconfirmation")]
        public async Task<IActionResult> CreateConfirmation(ConfirmationToCreateDto confirmationToCreateDto)
        {
            var confirmationToCreate = _mapper.Map<Confirmation>(confirmationToCreateDto);

            _repo.Add(confirmationToCreate);

            if (await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Failed to save the new confirmation");
        }

        [HttpPut("confirmation/{id}")]
        public async Task<IActionResult> UpdateConfirmation(int id, ConfirmationToUpdateDto confirmationToUpdateDto)
        {
            var confirmationFromRepo = await _repo.GetConfirmation(id);

            _mapper.Map(confirmationToUpdateDto, confirmationFromRepo);

            if (await _repo.SaveAll())
            {
                return NoContent();
            }

            throw new Exception($"Updating confirmation {id} failed on save");
        }
    }
}