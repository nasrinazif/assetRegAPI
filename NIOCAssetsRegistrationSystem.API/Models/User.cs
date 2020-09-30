using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Company Company { get; set; }
        public int? CompanyId { get; set; }
        public UserType UserType { get; set; }
        public int? UserTypeId { get; set; }
        public bool? HasPasswordEverChanged { get; set; } = false;
        public ICollection<CompaniesPropertyInquiry> CompaniesPropertyInquiries { get; set; }
        public ICollection<Confirmation> Confirmations { get; set; }
    }
}
