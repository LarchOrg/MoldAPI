using MoldApi.DTOs;
using MoldApi.Interfaces;

namespace MoldApi.Services
{
    public class MoldService : IMoldService
    {
        private readonly IMoldRepository _repo;

        public MoldService(IMoldRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<MoldDto>> GetAllMolds()
        {
            var molds = await _repo.GetAll();

            return molds.Select(m => new MoldDto
            {
                MoldId = m.MoldId,
                MoldName = m.MoldName
            }).ToList();
        }

        public async Task<MoldDto> GetMoldById(int id)
        {
            var mold = await _repo.GetById(id);

            if (mold == null)
                throw new Exception("Mold not found");

            return new MoldDto
            {
                MoldId = mold.MoldId,
                MoldName = mold.MoldName
                
            };
        }

        // ✅ Optimized dropdown
        public async Task<List<MoldDropdownDto>> GetMoldDropdown()
        {
            return await _repo.GetMoldDropdown();
        }
        public async Task<List<MoldDropdownDto>> GetPMDropdown()
        {
            return await _repo.GetPMDropdown();
        }
        public async Task<List<MouldPMPlanDto>> GetPMPlanDetails()
        {
            return await _repo.GetPMPlanDetails();
        }

        public async Task<string> InsertMoldPMSchedule(CreateMoldPMScheduleDto dto)
        {
            return await _repo.InsertMoldPMSchedule(dto);
        }


        public async Task<string> UpdateMoldPMSchedule(UpdateMoldPMScheduleDto dto)
        {
            return await _repo.UpdateMoldPMSchedule(dto);
        }

        public async Task<MoldPMScheduleIdDto> GetPMScheduleById(int id)
        {
            return await _repo.GetPMScheduleById(id);
        }
    }
}
