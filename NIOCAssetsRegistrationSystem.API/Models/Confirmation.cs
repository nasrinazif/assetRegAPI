using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Models
{
    public class Confirmation
    {
        public int Id { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public bool? Active { get; set; }
    }
}
