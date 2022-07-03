﻿using System.ComponentModel.DataAnnotations;

namespace Spotify.Model.DataTransferObject
{
    public class UserDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
