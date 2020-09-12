﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Models
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<CompaniesPropertyInquiry> CompaniesPropertyInquiries { get; set; }
    }
}
