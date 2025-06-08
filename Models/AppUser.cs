using System.ComponentModel.DataAnnotations;

namespace FootballManagerApi.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;

        [MaxLength(100)]
        public string? FullName { get; set; }     // To‘liq ism

        [EmailAddress]
        public string? Email { get; set; }        // Elektron pochta

        [Phone]
        public string? PhoneNumber { get; set; }  // Telefon raqami

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Ro‘yxatdan o‘tgan sana

        public bool IsActive { get; set; } = true; // Foydalanuvchi aktiv yoki bloklangan

    }
}
