namespace FootballManagerApi.DTOs;

public class GoalDto
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public string PlayerFullName { get; set; } // From Player.FirstName + LastName
    public int MatchId { get; set; }
    public DateTime MatchDate { get; set; }
    public int MinuteScored { get; set; }
}
