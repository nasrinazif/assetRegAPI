using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Dtos
{
    public class CityToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public int ProvinceId { get; set; }
    }
}
