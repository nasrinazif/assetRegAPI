﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NIOCAssetsRegistrationSystem.API.Dtos
{
    public class UserForChangePasswordDto
    {
        [Required]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 16 characters!")]
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool? HasPasswordEverChanged { get; set; }
    }
}
