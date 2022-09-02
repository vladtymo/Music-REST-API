﻿using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Track
    {
        public int Id { get; set; }
        //[Required, StringLength(100, MinimumLength = 2)]
        //[RegularExpression("$[A-Z]")]
        public string Name { get; set; }
        //[Range(1,10)]
        public float Rating { get; set; }
        public string? Duration { get; set; }
    }
}
