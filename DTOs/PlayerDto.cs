namespace FootballManagerApi.DTOs;

public class PlayerDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ShirtNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int TeamId { get; set; }
    public string Position { get; set; } // enum nomini string ko‘rinishda qaytarish uchun
}
