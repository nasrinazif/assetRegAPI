using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<CompaniesPropertyInquiry> CompaniesPropertyInquiries { get; set; }
        public ICollection<Confirmation> Confirmations { get; set; }
    }
}
