﻿using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class RegistViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}