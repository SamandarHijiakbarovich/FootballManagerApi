using System.ComponentModel.DataAnnotations;

namespace FootballManagerApi.DTOs;

public class UpdateGoalDto
{
    [Required]
    public int PlayerId { get; set; }

    [Required]
    public int MatchId { get; set; }

    [Required]
    [Range(1, 130, ErrorMessage = "Goal must be scored within 130 minutes.")]
    public int MinuteScored { get; set; }
}
