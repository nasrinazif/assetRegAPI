using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Dtos
{
    public class ConfirmationToCreateDto
    {
        public int Id { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public bool? Active { get; set; }        
        public int? CompanyId { get; set; }        
        public int? UserId { get; set; }
    }
}
