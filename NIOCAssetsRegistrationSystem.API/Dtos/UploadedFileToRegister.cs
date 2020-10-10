using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Dtos
{
    public class UploadedFileToRegister
    {
        public int Id { get; set; }
        public string FileName { get; set; }       
        public int? CompanyId { get; set; }        
        public int? UserId { get; set; }
        public DateTime? FileUploadDate { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }
}
