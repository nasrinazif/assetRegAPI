using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Dtos
{
    public class PropertiesToReturnDto
    {
        public int Id { get; set; }
        public string PropertyTitle { get; set; }
        public decimal? ArenaArea { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public int? ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int? CityId { get; set; }
        public string CityName { get; set; }
    }
}
