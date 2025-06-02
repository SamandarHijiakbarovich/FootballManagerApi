using System.ComponentModel.DataAnnotations;

namespace FootballManagerApi.DTOs;

public class CreateMatchDto
{
    [Required]
    public DateTime MatchDate { get; set; }

    [Required]
    public int HomeTeamId { get; set; }

    [Required]
    public int AwayTeamId { get; set; }
}
