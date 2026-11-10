using WarehouseManagement.API.DTOs.GoodsIssues;

namespace WarehouseManagement.API.Services.Interfaces;

public interface IGoodsIssueService
{
    // Bổ sung tham số employeeId lấy từ Controller (JWT Token)
    Task<GoodsIssueResponseDto> CreateIssueAsync(CreateGoodsIssueRequestDto request, int employeeId);

    Task<GoodsIssueResponseDto?> GetIssueByIdAsync(int id);
}