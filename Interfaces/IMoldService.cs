using MoldApi.DTOs;

namespace MoldApi.Interfaces
{
    public interface IMoldService
    {
        Task<List<MoldDto>> GetAllMolds();
        Task<MoldDto> GetMoldById(int id);

        Task<List<MoldDropdownDto>> GetMoldDropdown();
        Task<List<MoldDropdownDto>> GetPMDropdown();
        Task<string> InsertMoldPMSchedule(CreateMoldPMScheduleDto dto);

        Task<string> UpdateMoldPMSchedule(UpdateMoldPMScheduleDto dto);

        Task<MoldPMScheduleIdDto> GetPMScheduleById(int id);
    }
}
