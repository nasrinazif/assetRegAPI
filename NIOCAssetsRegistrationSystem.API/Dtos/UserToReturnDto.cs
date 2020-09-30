using NIOCAssetsRegistrationSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Dtos
{
    public class UserToReturnDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int? CompanyId { get; set; }
        public int? UserTypeId { get; set; }
        public string CompanyName { get; set; }
        public string UserTypeName { get; set; }
        public bool? HasPasswordEverChanged { get; set; }

    }
}
