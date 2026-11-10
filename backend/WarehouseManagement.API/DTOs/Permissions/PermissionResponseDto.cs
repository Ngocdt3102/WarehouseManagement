namespace WarehouseManagement.API.DTOs.Permissions;

public class PermissionResponseDto
{
    public int Id { get; set; }

    // Mã quyền (vd: PRODUCT_CREATE, GOODS_ISSUE_APPROVE)
    public string Code { get; set; } = null!;

    // Tên module để Frontend dễ dàng nhóm giao diện phân quyền (vd: PRODUCT, GOODS_ISSUE, INVENTORY)
    public string Module { get; set; } = null!;

    // Mô tả chi tiết quyền này làm gì
    public string? Description { get; set; }
}