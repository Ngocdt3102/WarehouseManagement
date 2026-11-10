using WarehouseManagement.API.DTOs.Auth;

namespace WarehouseManagement.API.Services.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    Task<LoginResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request); // Dùng lại LoginResponseDto
    Task<bool> ValidateTokenAsync(string token);
}