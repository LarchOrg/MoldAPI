namespace MoldApi.DTOs
{
    public class UpdateMouldCheckSheetDto
    {
        public int TransId { get; set; }
        public string? CurrentStatus { get; set; }
        public string? ActionTaken { get; set; }
        public IFormFile? BeforeImage { get; set; }
        public IFormFile? AfterImage { get; set; }
        public string? Remarks { get; set; }
    }
}
