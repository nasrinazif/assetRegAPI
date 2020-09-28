using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Dtos
{
    public class UploadedFileToReturnDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int? CompanyId { get; set; }        
        public int? UserId { get; set; }
        public DateTime? FileUploadDate { get; set; }
        public string Description { get; set; }
        public byte[] UploadedFile { get; set; }
        public string CompanyName { get; set; }        
        public string UserName { get; set; }
    }
}
