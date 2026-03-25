using MoldApi.DTOs;

namespace MoldApi.Interfaces
{
    public interface IMoldService
    {
        Task<List<MoldDto>> GetAllMolds();
        Task<MoldDto> GetMoldById(int id);

        Task<List<MoldDropdownDto>> GetMoldDropdown();
        Task<string> InsertMoldPMSchedule(CreateMoldPMScheduleDto dto);
    }
}
