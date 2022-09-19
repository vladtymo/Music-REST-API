﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class RegisterDTO
    {
        // TODO: add validations
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
