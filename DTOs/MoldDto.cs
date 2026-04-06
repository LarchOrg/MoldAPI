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
    public class PMMouldSpecFetchDto
    {
       
        public int Id { get; set; }
        public string MouldCode { get; set; }
        public string MouldName { get; set; }
        public string CheckPoint { get; set; }
        public string CheckMethod { get; set; }
        
        public string CheckAreas { get; set; }
        public string ReqCondition { get; set; }
        public string PMFreq { get; set; }
        public string ImageName { get; set; }
        public int Orderby { get; set; }
    }
    public class PMMouldMasterFetchDto
    {
       
        public int S_No { get; set; }
        public int Id { get; set; }
        public string MouldCode { get; set; }
        public string MouldName { get; set; }
        public int Size { get; set; }
        public int Cavity { get; set; }
        public string PartNo { get; set; }
        public long CurrentShot { get; set; }
        public long LifeShot { get; set; }
        public long OpeningShot { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
    }
}
