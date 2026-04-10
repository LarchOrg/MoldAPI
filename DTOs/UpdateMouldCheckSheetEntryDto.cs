// DTOs/UpdateMouldCheckSheetEntryDto.cs
namespace MoldApi.DTOs
{
    public class UpdateMouldCheckSheetEntryDto
    {
        public int ReportNo { get; set; }
        public string? PreparedBy { get; set; }
        public string? CheckedBy { get; set; }
        public string? ApprovedBy { get; set; }
        public int CreatedBy { get; set; }
    }
}