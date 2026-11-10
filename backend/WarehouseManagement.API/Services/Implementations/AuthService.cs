using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WarehouseManagement.API.DTOs.Auth;
using WarehouseManagement.API.Models;
using WarehouseManagement.API.Repositories.Interfaces;
using WarehouseManagement.API.Services.Interfaces;
using WarehouseManagement.API.Settings;

namespace WarehouseManagement.API.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly JwtSettings _jwtSettings;

    public AuthService(IUnitOfWork unitOfWork, IOptions<JwtSettings> jwtSettings)
    {
        _unitOfWork = unitOfWork;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
    {
        // 1. Tìm User (Đã bao gồm thông tin File Avatar nhờ Include trong Repository)
        var user = await _unitOfWork.Users.GetByUsernameAsync(request.Username);

        if (user == null)
            throw new UnauthorizedAccessException("Tài khoản không tồn tại hoặc đã bị khóa.");

        // 2. Kiểm tra mật khẩu
        if (user.Password != request.Password)
            throw new UnauthorizedAccessException("Mật khẩu không chính xác.");

        // 3. Lấy thông tin User kèm Role & Permission
        var userWithRoles = await _unitOfWork.Users.GetUserWithRolesAsync(user.Id);

        // 4. Bóc tách danh sách Roles và Permissions
        var roles = userWithRoles?.UserRoles
            .Select(ur => ur.Role?.Name)
            .Where(n => !string.IsNullOrEmpty(n))
            .Cast<string>()
            .ToList() ?? new List<string>();

        var permissions = new List<string>();
        if (userWithRoles?.UserRoles != null)
        {
            foreach (var ur in userWithRoles.UserRoles)
            {
                if (ur.Role?.RolePermissions != null)
                {
                    permissions.AddRange(ur.Role.RolePermissions
                        .Select(rp => rp.Permission?.Code)
                        .Where(c => !string.IsNullOrEmpty(c))
                        .Cast<string>());
                }
            }
        }
        permissions = permissions.Distinct().ToList();

        // 5. Cập nhật LastLoginAt
        user.LastLoginAt = DateTime.UtcNow;
        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveChangesAsync();

        // 6. Tạo JWT Access Token & Refresh Token
        var (accessToken, _) = GenerateJwtToken(user, roles, permissions);
        var refreshToken = GenerateRefreshToken();

        // 7. Trả về đúng cấu trúc DTO của bạn
        return new LoginResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            // Đổi phút ra giây cho chuẩn OAuth2
            ExpiresIn = _jwtSettings.AccessTokenExpirationMinutes * 60,
            User = new AuthUserDto
            {
                Id = user.Id,
                EmployeeCode = user.EmployeeCode,
                FullName = user.FullName,
                Username = user.Username,
                AvatarId = user.AvatarId,
                // Lấy DownloadUrl từ bảng File được nối vào qua Navigation Property Avatar
                AvatarUrl = user.Avatar?.DownloadUrl,
                Roles = roles,
                Permissions = permissions
            }
        };
    }

    public Task<LoginResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request)
    {
        throw new NotImplementedException("Chức năng Refresh Token cần bổ sung bảng lưu trữ Token vào Database.");
    }

    public Task<bool> ValidateTokenAsync(string token)
    {
        throw new NotImplementedException();
    }

    // --- Private Helper Methods ---

    private (string Token, DateTime Expires) GenerateJwtToken(User user, List<string> roles, List<string> permissions)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim("FullName", user.FullName),
            new Claim("EmployeeCode", user.EmployeeCode)
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        foreach (var permission in permissions)
        {
            claims.Add(new Claim("Permission", permission));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: expires,
            signingCredentials: creds
        );

        return (new JwtSecurityTokenHandler().WriteToken(token), expires);
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}