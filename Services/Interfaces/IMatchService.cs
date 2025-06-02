using FootballManagerApi.DTOs;

namespace FootballManagerApi.Services.Interfaces
{
    public interface IMatchService
    {
        Task<List<MatchDto>> GetAllAsync();
        Task<MatchDto?> GetByIdAsync(int id);
        Task<MatchDto> CreateAsync(CreateMatchDto dto);
        Task<bool> UpdateAsync(int id, UpdateMatchDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
