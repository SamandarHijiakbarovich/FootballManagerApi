using System.ComponentModel.DataAnnotations;

namespace FootballManagerApi.Models;

public class Team
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Team name is required.")]
    [MaxLength(100, ErrorMessage = "Team name cannot exceed 100 characters.")]
    public string Name { get; set; }

    public int Points { get; set; }

    [Required(ErrorMessage = "City is required.")]
    [MaxLength(100, ErrorMessage = "City name cannot exceed 100 characters.")]
    public string? City { get; set; }

    public List<Player> Players { get; set; } = new();
    public List<Match> HomeMatches { get; set; } = new();
    public List<Match> AwayMatches { get; set; } = new();
}
