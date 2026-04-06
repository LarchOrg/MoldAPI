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

        Task<List<CheckAreaDto>> GetMoldCheckArea();
        Task<List<CheckPointDto>> GetMoldCheckPoint();
        Task<List<ReqConditionDto>> GetMoldReqCondition();
        Task<List<PMMouldSpecFetchDto>> GetMoldSpecFetch();
        Task<List<MoldPlanCheckSheetFetchDto>> GetPMCheckSheetFetch();
        Task<List<PMMouldMasterFetchDto>> GetMouldMstFetch();
        Task<List<CheckMethodDto>> GetMoldCheckMethod();
        Task<string> InsertMoldPMSchedule(CreateMoldPMScheduleDto dto);
        Task<string> InsertMaintenanceSpecEntry(CreateMaintenanceSpecEntryDto dto);
        Task<string> UpdateMoldPMSchedule(UpdateMoldPMScheduleDto dto);
        Task<string> DeletePMPlan(int id);

        Task<MoldPMScheduleIdDto> GetPMScheduleById(int id);
    }

}
