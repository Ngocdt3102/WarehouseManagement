using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.API.DTOs.GoodsIssues;

public class CreateGoodsIssueRequestDto
{
    [Required(ErrorMessage = "Khách hàng là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "ID Khách hàng không hợp lệ.")]
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "Kho xuất là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "ID Kho không hợp lệ.")]
    public int WarehouseId { get; set; }

    [Required(ErrorMessage = "Ngày xuất là bắt buộc.")]
    public DateTime Date { get; set; }

    [StringLength(500, ErrorMessage = "Ghi chú không vượt quá 500 ký tự.")]
    public string? Remarks { get; set; }

    [Required(ErrorMessage = "Danh sách sản phẩm không được để trống.")]
    [MinLength(1, ErrorMessage = "Phải có ít nhất 1 sản phẩm trong phiếu xuất.")]
    public List<GoodsIssueDetailDto> Details { get; set; } = new List<GoodsIssueDetailDto>();

    // Tương tự phiếu nhập, EmployeeId (Người lập phiếu) sẽ được lấy từ JWT Token ở Controller
}