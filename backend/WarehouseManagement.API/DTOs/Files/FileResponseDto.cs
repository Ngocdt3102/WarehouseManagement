namespace WarehouseManagement.API.DTOs.Files;

public class FileResponseDto
{
    public int Id { get; set; }
    public string FileName { get; set; } = null!;
    public string ContentType { get; set; } = null!;

    // Kích thước file (Bytes)
    public long Length { get; set; }

    // Đường dẫn/URL để Frontend gọi API tải (Download) hoặc hiển thị file (Ảnh)
    public string DownloadUrl { get; set; } = null!;

    public DateTime UploadedAt { get; set; }
}