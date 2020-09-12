using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Province Province { get; set; }
        public int ProvinceId { get; set; }
        public ICollection<CompaniesPropertyInquiry> CompaniesPropertyInquiries { get; set; }
    }
}
