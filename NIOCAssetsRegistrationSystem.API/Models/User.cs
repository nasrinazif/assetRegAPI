﻿using System;
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
        public ICollection<CompaniesPropertyInquiry> CompaniesPropertyInquiries { get; set; }
        public ICollection<Confirmation> Confirmations { get; set; }
    }
}
