﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ResetPasswordDTO
    {
        public string UserEmail { get; set; }
        public string NewPassword { get; set; }
        public string Token { get; set; }
    }
}
