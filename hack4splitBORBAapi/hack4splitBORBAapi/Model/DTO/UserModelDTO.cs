using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace hack4splitBORBAapi.Model.DTO
{
    public class UserModelDTO
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
