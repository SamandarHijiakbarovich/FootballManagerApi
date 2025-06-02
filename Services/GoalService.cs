using FootballManagerApi.DTOs;
using FootballManagerApi.Services.Interfaces;

namespace FootballManagerApi.Services
{
    public class GoalService : IGoalService
    {
        public Task<GoalDto> CreateAsync(CreateGoalDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GoalDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GoalDto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, UpdateGoalDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
