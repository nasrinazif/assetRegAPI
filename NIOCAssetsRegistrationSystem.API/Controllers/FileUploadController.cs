using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
    public class FileUploadController : ControllerBase
    {
        private readonly IAssetRegistrationRepository _repo;
        private readonly IMapper _mapper;
        public FileUploadController(IAssetRegistrationRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        [HttpGet("file/{id}")]
        public async Task<IActionResult> GetFile(int id)
        {
            /* Get the file from the asset repo by its id*/
            var uploadedFileFromRepo = await _repo.GetUploadedFileAsync(id);

            /* Refrences to related entities*/
            var companyCode = uploadedFileFromRepo.CompanyId.GetValueOrDefault();
            uploadedFileFromRepo.Company = _repo.GetCompany(companyCode);

            var userCode = uploadedFileFromRepo.UserId.GetValueOrDefault();
            uploadedFileFromRepo.User = _repo.GetUserSync(userCode);

            /* Return the file*/
            var uploadedFile = _mapper.Map<UploadedFileToReturnDto>(uploadedFileFromRepo);

            return Ok(uploadedFile);
        }

        [HttpGet("files")]
        public async Task<IActionResult> GetFiles(int id)
        {
            /* Get the files from the asset repo by its id*/
            var uploadedFilesFromRepo = await _repo.GetUploadedFilesAsync();

            /* Refrences to related entities*/
            foreach(var uploadedFileFromRepo in uploadedFilesFromRepo)
            {
                var companyCode = uploadedFileFromRepo.CompanyId.GetValueOrDefault();
                uploadedFileFromRepo.Company = _repo.GetCompany(companyCode);

                var userCode = uploadedFileFromRepo.UserId.GetValueOrDefault();
                uploadedFileFromRepo.User = _repo.GetUserSync(userCode);

            }
            
            /* Return the files*/
            var uploadedFiles = _mapper.Map<IEnumerable<UploadedFileToReturnDto>>(uploadedFilesFromRepo);

            return Ok(uploadedFiles);
        }

        [HttpGet("files/company/{id}")]
        public async Task<IActionResult> GetFilesByCompany(int id)
        {
            /* Get the files from the asset repo by its id*/
            var uploadedFilesFromRepo = await _repo.GetUploadedFilesByCompanyIdAsync(id);

            /* Refrences to related entities*/
            foreach (var uploadedFileFromRepo in uploadedFilesFromRepo)
            {
                var companyCode = uploadedFileFromRepo.CompanyId.GetValueOrDefault();
                uploadedFileFromRepo.Company = _repo.GetCompany(companyCode);

                var userCode = uploadedFileFromRepo.UserId.GetValueOrDefault();
                uploadedFileFromRepo.User = _repo.GetUserSync(userCode);

            }

            /* Return the files*/
            var uploadedFiles = _mapper.Map<IEnumerable<UploadedFileToReturnDto>>(uploadedFilesFromRepo);

            return Ok(uploadedFiles);
        }

        [HttpDelete("file/{id}")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            var fileToDelete = _repo.GetUploadedFile(id);

            _repo.DeleteUploadedFile(fileToDelete);

            if (await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Failed to delete the file");
        }

        [HttpPost("uploadfile")]
        public async Task<IActionResult> UploadFile([FromForm]UploadedFileToRegister uploadedFileToRegister)
        {
            var file = uploadedFileToRegister.File;            
            var folderName = Path.Combine("Files", uploadedFileToRegister.CompanyId.ToString());
            Directory.CreateDirectory(folderName);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                var fileToAdd = _mapper.Map<FileUpload>(uploadedFileToRegister);

                fileToAdd.FilePath = dbPath;

                _repo.Add(fileToAdd);

                if (await _repo.SaveAll())
                {
                    return Ok();
                }
            }            

            

            return BadRequest("Failed to save the new property");
        }
    }
}