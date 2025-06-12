using System.ComponentModel.DataAnnotations;

namespace FootballManagerApi.DTOs.UserDto
{
    public class UserLoginDto
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
