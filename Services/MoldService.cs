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
        public async Task<AllDropdownsDto> GetAllDropdowns()
        {
            var areas = await _repo.GetMoldCheckArea();
            var methods = await _repo.GetMoldCheckMethod();
            var points = await _repo.GetMoldCheckPoint();
            var conditions = await _repo.GetMoldReqCondition();
            var partno = await _repo.GetPartNo();


            return new AllDropdownsDto
            {
                CheckAreas = areas,
                CheckMethod = methods,
                CheckPoint = points,
                ReqCondition = conditions,
                PartNoDrp = partno
            };
        }
        public async Task<List<MoldDropdownDto>> GetMoldImgDropdown()
        {
            return await _repo.GetMoldImgDropdown();
        }
        public async Task<List<PMMouldSpecFetchDto>> GetMoldSpecFetch()
        {
            return await _repo.GetMoldSpecFetch();
        }
        public async Task<List<MoldDropdownDto>> GetPMDropdown()
        {
            return await _repo.GetPMDropdown();
        }
        public async Task<List<MouldPMPlanDto>> GetPMPlanDetails()
        {
            return await _repo.GetPMPlanDetails();
        }
        public async Task<List<MoldPlanCheckSheetFetchDto>> GetPMCheckSheetFetch()
        {
            return await _repo.GetPMCheckSheetFetch();
        }
        public async Task<List<PMMouldMasterFetchDto>> GetMouldMstFetch()
        {
            return await _repo.GetMouldMstFetch();
        }

        public async Task<string> InsertMoldPMSchedule(CreateMoldPMScheduleDto dto)
        {
            return await _repo.InsertMoldPMSchedule(dto);
        }

        public async Task<string> InsertMaintenanceSpecEntry(CreateMaintenanceSpecEntryDto dto)
        {
            return await _repo.InsertMaintenanceSpecEntry(dto);
        }
        public async Task<string> InsertMoldMst(InsertMouldMstDto dto)
        {
            return await _repo.InsertMoldMst(dto);
        }
        public async Task<string> InsertCheckMasterAsync(CheckInsertDto dto)
        {
            return await _repo.InsertCheckMasterAsync(dto);
        }
        public async Task<string> UpdateMoldPMSchedule(UpdateMoldPMScheduleDto dto)
        {
            return await _repo.UpdateMoldPMSchedule(dto);
        }

        public async Task<string> UpdateMoldMst(UpdateMouldMstDto dto)
        {
            return await _repo.UpdateMoldMst(dto);
        }
        public async Task<string> UpdateSpecEnrty(UpdateSpecEntrybyIdDto dto)
        {
            return await _repo.UpdateSpecEnrty(dto);
        }
        public async Task<string> DeletePMPlan(int id)
        {
            return await _repo.DeletePMPlan(id);
        }
        public async Task<string> DeletePMSpec(int id)
        {
            return await _repo.DeletePMSpec(id);
        }

        public async Task<MouldMstByIdDto> GetMouldMstById(int id)
        {
            return await _repo.GetMouldMstById(id);
        }
        public async Task<MoldPMScheduleIdDto> GetPMScheduleById(int id)
        {
            return await _repo.GetPMScheduleById(id);
        }
        public async Task<MaintenanceSpecEntrybyIdDto> GetSpecEntryById(int id)

        {
            return await _repo.GetSpecEntryById(id);
        }
    }
}
