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
        Task<string> UpdateMoldPMSchedule(UpdateMoldPMScheduleDto dto);
        Task<string> DeletePMPlan(int id);

        Task<MoldPMScheduleIdDto> GetPMScheduleById(int id);
    }
}
