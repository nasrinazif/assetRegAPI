using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Models
{
    public class FileUpload
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public Company Company { get; set; }
        public int? CompanyId { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }
        public DateTime? FileUploadDate { get; set; }
        public string Description { get; set; }
        public byte[] UploadedFile { get; set; }
    }
}
