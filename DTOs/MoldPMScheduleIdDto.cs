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
    public class MoldPlanCheckSheetFetchDto
    {

        public int TransId { get; set; }
        public string ReportNo { get; set; }
        public string Mould { get; set; }
        public string PartNo { get; set; }
        public string PMFreq { get; set; }
        public string TargetDate { get; set; } 
        public string Status { get; set; } 
    }
}
