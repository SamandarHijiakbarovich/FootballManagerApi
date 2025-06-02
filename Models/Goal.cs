using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManagerApi.Models;

public class Goal
{
    [Key]
    public int Id { get; set; }
    [Required]
    [ForeignKey("Player")]
    public int PlayerId { get; set; }

    [Required]
    [ForeignKey("Match")]
    public int MatchId { get; set; }

    [Required]
    [Range(1, 130, ErrorMessage = "Goal must be scored within 130 minutes.")]
    public int MinuteScored { get; set; }
    public Player Player { get; set; }
    public Match Match { get; set; }
}
