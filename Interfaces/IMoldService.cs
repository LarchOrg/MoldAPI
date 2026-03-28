using MoldApi.DTOs;

namespace MoldApi.Interfaces
{
    public interface IMoldService
    {
        Task<List<MoldDto>> GetAllMolds();
        Task<MoldDto> GetMoldById(int id);

        Task<List<MoldDropdownDto>> GetMoldDropdown();
        Task<List<MoldDropdownDto>> GetMoldImgDropdown();
        Task<List<MoldDropdownDto>> GetPMDropdown();
        Task<List<MouldPMPlanDto>> GetPMPlanDetails();
        Task<string> InsertMoldPMSchedule(CreateMoldPMScheduleDto dto);

        Task<string> UpdateMoldPMSchedule(UpdateMoldPMScheduleDto dto);
        Task<string> DeletePMPlan(int id);

        Task<MoldPMScheduleIdDto> GetPMScheduleById(int id);
    }
}
