using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManagerApi.Models;

public class Match
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Match date is required.")]
    public DateTime MatchDate { get; set; }


    [Range(0, int.MaxValue)]
    public int HomeTeamScore { get; set; }

    [Range(0, int.MaxValue)]
    public int AwayTeamScore { get; set; }
    [Required]
    [ForeignKey("HomeTeam")]
    public int HomeTeamId { get; set; }

    public Team HomeTeam { get; set; }


    [Required]
    [ForeignKey("AwayTeam")]
    public int AwayTeamId { get; set; }
    public Team AwayTeam { get; set; }
    public ICollection<Goal> Goals { get; set; } = new List<Goal>();
}
