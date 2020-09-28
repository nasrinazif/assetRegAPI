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
    public class FileUploadController : ControllerBase
    {
        private readonly IAssetRegistrationRepository _repo;
        private readonly IMapper _mapper;
        public FileUploadController(IAssetRegistrationRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        [HttpGet("file/{id}"]
        public async Task<IActionResult> GetFile(int id)
        {
            /* Get the property from the asset repo by its id*/
            var uploadedFileFromRepo = await _repo.GetUploadedFileAsync(id);

            /* Refrences to related entities*/
            var companyCode = uploadedFileFromRepo.CompanyId.GetValueOrDefault();
            uploadedFileFromRepo.Company = _repo.GetCompany(companyCode);

            var userCode = uploadedFileFromRepo.UserId.GetValueOrDefault();
            uploadedFileFromRepo.User = _repo.GetUserSync(userCode);

            /* Return the property*/
            var uploadedFile = _mapper.Map<UploadedFileToReturnDto>(uploadedFileFromRepo);

            return Ok(uploadedFile);
        }
}