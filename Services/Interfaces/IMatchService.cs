using FootballManagerApi.DTOs;

namespace FootballManagerApi.Services.Interfaces
{
    public interface IMatchService
    {
        Task<List<MatchDto>> GetMatchesAllAsync();
        Task<MatchDto?> GetMatchByIdAsync(int id);
        Task<MatchDto> CreateMatchAsync(CreateMatchDto dto);
        Task<bool> UpdateMatchAsync(int id, UpdateMatchDto dto);
        Task<bool> DeleteMatchAsync(int id);
    }
}
