namespace MoldApi.DTOs
{
    public class MoldDto
    {
        public int MoldId { get; set; }
        public string MoldName { get; set; }
    }
    public class CreateMaintenanceSpecEntryDto
    {
       
        public int MouldMachineId { get; set; }
        public int CheckPoint { get; set; }
        public int CheckMethod { get; set; }
        public int PMFreq { get; set; }
        public int ImgId { get; set; }
        public int Orderby { get; set; }
        public int CreatedBy { get; set; }
        public int CheckAreaId { get; set; }
        public int ResultId { get; set; }
    }
}
