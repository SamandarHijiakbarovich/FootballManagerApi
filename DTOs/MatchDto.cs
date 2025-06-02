namespace FootballManagerApi.DTOs;

public class MatchDto
{
    public int Id { get; set; }
    public DateTime MatchDate { get; set; }

    public int HomeTeamId { get; set; }
    public string HomeTeamName { get; set; }

    public int AwayTeamId { get; set; }
    public string AwayTeamName { get; set; }

    public int HomeTeamScore { get; set; }
    public int AwayTeamScore { get; set; }
}
