namespace MoldApi.DTOs
{
    public class MoldDto
    {
        public int MoldId { get; set; }
        public string MoldName { get; set; }
    }

    public class CheckInsertDto
    {
        public string Type { get; set; }   // AREA | POINT | METHOD | RESULT
        public string Name { get; set; }
        public int CreatedBy { get; set; }
    }
    public class UpdateMouldMstDto
    {

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }

        public long Cavity { get; set; }
        public long OpeningShot { get; set; }
        public long LifeShot { get; set; }
        public long CurrentShot { get; set; }

        public string Location { get; set; }
        public int Item { get; set; }

        public DateOnly UsedFrom { get; set; }

        public string Category { get; set; }
        public int PMFreq { get; set; }

        public int PMFreqDays { get; set; }
        public int PMFreqShots { get; set; }

        public string Color { get; set; }
        public string Supplier { get; set; }
        public string MakerSupplier { get; set; }

        public string Remarks { get; set; }

        public int UpdatedBy { get; set; }

        public string Barcode { get; set; }
        public string Direction { get; set; }
    }
    public class InsertMouldMstDto
    {

        public string Code { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }

        public long Cavity { get; set; }
        public long OpeningShot { get; set; }
        public long LifeShot { get; set; }
        public long CurrentShot { get; set; }

        public string Location { get; set; }
        public int Item { get; set; }

        public DateOnly UsedFrom { get; set; }

        public string Category { get; set; }
        public int PMFreq { get; set; }

        public int PMFreqDays { get; set; }
        public int PMFreqShots { get; set; }

        public string Color { get; set; }
        public string Supplier { get; set; }
        public string MakerSupplier { get; set; }

        public string Remarks { get; set; }

        public int CreatedBy { get; set; }

        public string Barcode { get; set; }
        public string Direction { get; set; }
    }
    public class ERRORAPIDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
    public class MaintenanceSpecEntrybyIdDto
    {

        public int TransId { get; set; }
        public int MaintenanceId { get; set; }
        public int MouldMachineId { get; set; }
        public int PMFreqId { get; set; }
        public int CheckPointId { get; set; }
        public int CheckMethodId { get; set; }
        public int CheckAreaId { get; set; }
        public int ImgId { get; set; }
        public int OrderBy { get; set; }
        public int ReqConditionId { get; set; }
    }
    public class UpdateSpecEntrybyIdDto
    {

        public int Id { get; set; }
        public int PMFreqId { get; set; }
        public int CheckPointId { get; set; }
        public int CheckMethodId { get; set; }
        public int CheckAreaId { get; set; }
        public int ImgId { get; set; }
        public int OrderBy { get; set; }
        public int ReqConditionId { get; set; }
        public int UpdateBy { get; set; }
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

    public class CreateCheckSheetDto
    {
        public int ReportNo { get; set; }
        public string PrepareBy { get; set; }
        public int CreatedBy { get; set; }
    }

    public class MouldMstByIdDto
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string BarCode { get; set; }   // matches mld_vBarcode

        public string Name { get; set; }
        public string Size { get; set; }

        public int Cavity { get; set; }
        public int OpeningShot { get; set; }
        public int LifeShot { get; set; }
        public int CurrentShot { get; set; }

        public string Location { get; set; }
        public int Item { get; set; }

        public string PartNo { get; set; }

        public string UsedFrom { get; set; }

        public string Category { get; set; }

        public string PMFreq { get; set; }   // varchar in DB

        public int PMFreqDays { get; set; }
        public int PMFreqShots { get; set; }

        public string Color { get; set; }

        public string Supplier { get; set; }
        public string MakerSupplier { get; set; }

        public string Remarks { get; set; }

        public string Direction { get; set; }
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
        public long S_No { get; set; }
        public int Id { get; set; }
        public string MouldCode { get; set; }
        public string MouldName { get; set; }
        public string Size { get; set; }   
        public int Cavity { get; set; }
        public string PartNo { get; set; }
        public long CurrentShot { get; set; }  
        public long LifeShot { get; set; }  
        public long OpeningShot { get; set; } 
        public string Category { get; set; }
        public string Status { get; set; }
    }
}
