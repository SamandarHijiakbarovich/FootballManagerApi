using FootballManagerApi.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManagerApi.Models;

public class Player
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "First name is required.")]
    [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
    public string  LastName { get; set; }

    [Required(ErrorMessage = "Shirt number is required.")]
    [Range(1, 99, ErrorMessage = "Shirt number must be between 1 and 99.")]
    public int ShirtNumber { get; set; }
    [Required(ErrorMessage = "Date of birth is required.")]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [ForeignKey("Team")]
    public int TeamId { get; set; }
    
    [Required(ErrorMessage = "Position is required.")]
    public Position Position { get; set; }
    public Team Team { get; set; }
    public ICollection<Goal> Goals { get; set; }

}
