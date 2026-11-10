using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.Auth;

public class RefreshTokenRequestDto
{
    [Required(ErrorMessage = "AccessToken là bắt buộc.")]
    public string AccessToken { get; set; } = null!;

    [Required(ErrorMessage = "RefreshToken là bắt buộc.")]
    public string RefreshToken { get; set; } = null!;
}