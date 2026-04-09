namespace MoldApi.DTOs
{
    public class MoldDropdownDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CheckAreaDto
    {
        public int Id { get; set; }
        public string CheckAreas { get; set; }
    }
    public class PartNoDrpDto
    {
        public int Id { get; set; }
        public string PartNo { get; set; }
    }

    public class CheckMethodDto
    {
        public int Id { get; set; }
        public string CheckMethod { get; set; }
    }

    public class CheckPointDto
    {
        public int Id { get; set; }
        public string CheckPoint { get; set; }
    }
    public class CurrentStsDto
    {
        public int Id { get; set; }
        public string CurrentStatus { get; set; }
        public string Type { get; set; }


    }

    public class ReqConditionDto
    {
        public int Id { get; set; }
        public string ReqCondition { get; set; }
    }

    // Wrapper returned to client - built manually in service
    public class AllDropdownsDto
    {
        public List<CheckAreaDto> CheckAreas { get; set; }
        public List<PartNoDrpDto> PartNoDrp { get; set; }
        public List<CheckMethodDto> CheckMethod { get; set; }
        public List<CheckPointDto> CheckPoint { get; set; }
        public List<ReqConditionDto> ReqCondition { get; set; }
        public List<CurrentStsDto> CurrentSts { get; set; }
    }
}
