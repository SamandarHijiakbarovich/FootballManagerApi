using System.ComponentModel.DataAnnotations;

namespace FootballManagerApi.DTOs;

public class UpdateMatchDto
{
    [Required]
    public DateTime MatchDate { get; set; }

    [Required]
    public int HomeTeamId { get; set; }

    [Required]
    public int AwayTeamId { get; set; }

    [Range(0, int.MaxValue)]
    public int HomeTeamScore { get; set; }

    [Range(0, int.MaxValue)]
    public int AwayTeamScore { get; set; }
}
