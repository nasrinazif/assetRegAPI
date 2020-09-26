using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Dtos
{
    public class ConfirmationToUpdateDto
    {
        public DateTime? ConfirmDate { get; set; }
        public bool? Active { get; set; }
    }
}
