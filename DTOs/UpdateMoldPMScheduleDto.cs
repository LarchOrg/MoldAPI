namespace MoldApi.DTOs
{
    public class UpdateMoldPMScheduleDto
    {
        public int Id { get; set; }
        public string dDate { get; set; }  // keep string if your SP expects dd/MM/yyyy
    }
}
