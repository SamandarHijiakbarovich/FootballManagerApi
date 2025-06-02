using FootballManagerApi.DTOs;

namespace FootballManagerApi.Services.Interfaces
{
    public interface ITeamService
    {
        Task<List<TeamDto>> GetAllTeamsAsync();
        Task<TeamDto> GetTeamByIdAsync(int id);
        Task<TeamDto> CreateTeamAsync(CreateTeamDto newTeam);
        Task<bool> UpdateTeamAsync(int id, UpdateTeamDto updatedTeam);
        Task<bool> DeleteTeamAsync(int id);
    }
}
