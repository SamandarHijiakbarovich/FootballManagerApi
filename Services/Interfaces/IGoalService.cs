using FootballManagerApi.DTOs;

namespace FootballManagerApi.Services.Interfaces
{
    public interface IGoalService
    {
        Task<List<GoalDto>> GetAllAsync();
        Task<GoalDto?> GetByIdAsync(int id);
        Task<GoalDto> CreateAsync(CreateGoalDto dto);
        Task<bool> UpdateAsync(int id, UpdateGoalDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
