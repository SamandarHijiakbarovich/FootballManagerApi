namespace FootballManagerApi.DTOs.UserDto
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }
        public string? Token { get; set; }  // Bu login va register natijasida frontendga qaytadi

    }
}
