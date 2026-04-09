using MoldApi.DTOs;
using MoldApi.Entities;

namespace MoldApi.Interfaces
{
    public interface IMoldRepository
    {
        Task<List<Mold>> GetAll();
        Task<Mold> GetById(int id);

        Task<List<MoldDropdownDto>> GetMoldDropdown();
        Task<List<MoldDropdownDto>> GetMoldImgDropdown();
        Task<List<MoldDropdownDto>> GetPMDropdown();
        Task<List<MouldPMPlanDto>> GetPMPlanDetails();
        Task<List<CurrentStsDto>> GetCurrentSts();
        Task<List<PartNoDrpDto>> GetPartNo();
        Task<List<CheckAreaDto>> GetMoldCheckArea();
        Task<List<CheckPointDto>> GetMoldCheckPoint();
        Task<List<ReqConditionDto>> GetMoldReqCondition();
        Task<List<PMMouldSpecFetchDto>> GetMoldSpecFetch();
        Task<List<MoldPlanCheckSheetFetchDto>> GetPMCheckSheetFetch();
        Task<List<PMMouldMasterFetchDto>> GetMouldMstFetch();
        Task<List<CheckMethodDto>> GetMoldCheckMethod();
        Task<string> InsertMoldPMSchedule(CreateMoldPMScheduleDto dto);
        Task<string> InsertMoldMst(InsertMouldMstDto dto);
        Task<string> CreateCheckSheet(CreateCheckSheetDto dto);
        Task<string> InsertMaintenanceSpecEntry(CreateMaintenanceSpecEntryDto dto);
        Task<string> UpdateMoldPMSchedule(UpdateMoldPMScheduleDto dto);
        Task<string> UpdateMoldMst(UpdateMouldMstDto dto);
        Task<string> UpdateSpecEnrty(UpdateSpecEntrybyIdDto dto);
        Task<string> DeletePMPlan(int id);
        Task<string> DeletePMSpec(int id);
        Task<string> InsertCheckMasterAsync(CheckInsertDto dto);
        Task<MaintenanceSpecEntrybyIdDto> GetSpecEntryById(int id);
        Task<MoldPMScheduleIdDto> GetPMScheduleById(int id);
        Task<List<MouldReportDto>> GetCheckSheetDetails(int id);
        Task<MouldMstByIdDto> GetMouldMstById(int id);
    }

}
