using MoldApi.DTOs;

namespace MoldApi.Interfaces
{
    public interface IMoldService
    {
        Task<List<MoldDto>> GetAllMolds();
        Task<MoldDto> GetMoldById(int id);

        Task<List<MoldDropdownDto>> GetMoldDropdown();
        Task<List<MoldDropdownDto>> GetMoldImgDropdown();

        Task<AllDropdownsDto> GetAllDropdowns();
        Task<List<MoldDropdownDto>> GetPMDropdown();
        Task<List<PMMouldSpecFetchDto>> GetMoldSpecFetch();
        Task<List<MoldPlanCheckSheetFetchDto>> GetPMCheckSheetFetch();
        Task<List<PMMouldMasterFetchDto>> GetMouldMstFetch();

        Task<List<MouldPMPlanDto>> GetPMPlanDetails();
        Task<string> InsertMoldPMSchedule(CreateMoldPMScheduleDto dto);
        Task<string> InsertMaintenanceSpecEntry(CreateMaintenanceSpecEntryDto dto);
        Task<string> InsertMoldMst(InsertMouldMstDto dto);
        Task<string> CreateCheckSheet(CreateCheckSheetDto dto);
        Task<string> UpdateMoldPMSchedule(UpdateMoldPMScheduleDto dto);
        Task<string> UpdateMoldMst(UpdateMouldMstDto dto);
        Task<string> UpdateSpecEnrty(UpdateSpecEntrybyIdDto dto);

        Task<string> InsertCheckMasterAsync(CheckInsertDto dto);
        Task<string> DeletePMPlan(int id);
        Task<string> DeletePMSpec(int id);
        Task<MouldMstByIdDto> GetMouldMstById(int id);
        Task<MaintenanceSpecEntrybyIdDto> GetSpecEntryById(int id);
        Task<MoldPMScheduleIdDto> GetPMScheduleById(int id);
    }
}
