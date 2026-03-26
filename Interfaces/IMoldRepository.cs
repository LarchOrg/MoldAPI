using MoldApi.DTOs;
using MoldApi.Entities;

namespace MoldApi.Interfaces
{
    public interface IMoldRepository
    {
        Task<List<Mold>> GetAll();
        Task<Mold> GetById(int id);

        Task<List<MoldDropdownDto>> GetMoldDropdown();
        Task<List<MoldDropdownDto>> GetPMDropdown();

        Task<string> InsertMoldPMSchedule(CreateMoldPMScheduleDto dto);

        Task<string> UpdateMoldPMSchedule(UpdateMoldPMScheduleDto dto);

        Task<MoldPMScheduleIdDto> GetPMScheduleById(int id);
    }

}
