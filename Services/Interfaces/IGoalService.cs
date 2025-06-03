using FootballManagerApi.DTOs;

namespace FootballManagerApi.Services.Interfaces
{
    public interface IGoalService
    {
        Task<List<GoalDto>> GetGoalAllAsync();
        Task<GoalDto?> GetGoalByIdAsync(int id);
        Task<GoalDto> CreateGoalAsync(CreateGoalDto dto);
        Task<bool> UpdateGoalAsync(int id, UpdateGoalDto dto);
        Task<bool> DeleteGoalAsync(int id);
    }
}
