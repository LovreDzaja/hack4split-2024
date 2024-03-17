using System.ComponentModel.DataAnnotations;

namespace hack4splitBORBAapi.Model.DTO
{
    public class UserModelDTOForLogin
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
