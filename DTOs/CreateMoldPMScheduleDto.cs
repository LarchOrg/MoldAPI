namespace MoldApi.DTOs
{
    public class CreateMoldPMScheduleDto
    {
        public string dDate { get; set; }
        public int iMouldId { get; set; }
        public int iPMFreq { get; set; }
        public int iCreatedBy { get; set; }
    }
}
