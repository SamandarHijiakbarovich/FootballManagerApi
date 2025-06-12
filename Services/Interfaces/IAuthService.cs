using FootballManagerApi.DTOs.UserDto;

namespace FootballManagerApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto> RegisterAsync(UserRegisterDto dto);
        Task<UserDto> LoginAsync(UserLoginDto dto);
    }
}
