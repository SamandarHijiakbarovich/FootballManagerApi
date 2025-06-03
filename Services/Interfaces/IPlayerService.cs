using FootballManagerApi.DTOs;

namespace FootballManagerApi.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<List<PlayerDto>> GetAllPlayerAsync();
        Task<PlayerDto?> GetPlayerByIdAsync(int id);
        Task<PlayerDto> CreateAsync(CreatePlayerDto dto);
        Task<bool> UpdateAsync(int id, UpdatePlayerDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
