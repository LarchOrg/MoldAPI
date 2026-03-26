namespace MoldApi.DTOs
{
    public class MoldPMScheduleIdDto
    {

        public int TransId { get; set; }
        public string ReportNo { get; set; }
        public int MouldId { get; set; }
        public int PMFreqId { get; set; }
        public string Date { get; set; } // dd/MM/yyyy from SP
    }
}
