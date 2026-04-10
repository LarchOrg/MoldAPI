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
            var currentstatus = await _repo.GetCurrentSts();


            return new AllDropdownsDto
            {
                CheckAreas = areas,
                CheckMethod = methods,
                CheckPoint = points,
                ReqCondition = conditions,
                PartNoDrp = partno,
                CurrentSts = currentstatus
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

        public async Task<string> CreateCheckSheet(CreateCheckSheetDto dto)
        {
            return await _repo.CreateCheckSheet(dto);
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
        public async Task<List<MouldReportDto>> GetCheckSheetDetails(int id)

        {
            return await _repo.GetCheckSheetDetails(id);
        }


        public async Task<string> UpdateMouldCheckSheet(UpdateMouldCheckSheetDto dto)
        {
            try
            {
                string? beforeImageName = null;
                string? afterImageName = null;

                // 2 levels up from app (out of YourApp, out of wwwroot)
                // Result: C:\inetpub\UploadImages\
                // 0 levels up - folder is inside project
                string baseFolder = Path.GetFullPath(
                    Path.Combine(Directory.GetCurrentDirectory(), "UploadImages"));
                string beforeFolder = Path.Combine(baseFolder, "BeforeImages");
                string afterFolder = Path.Combine(baseFolder, "AfterImages");

                // Create folders if they don't exist
                if (!Directory.Exists(beforeFolder))
                    Directory.CreateDirectory(beforeFolder);

                if (!Directory.Exists(afterFolder))
                    Directory.CreateDirectory(afterFolder);

                // Save Before Image
                if (dto.BeforeImage != null && dto.BeforeImage.Length > 0)
                {
                    string beforeExt = Path.GetExtension(dto.BeforeImage.FileName);
                    beforeImageName = $"Before_{dto.TransId}_{DateTime.Now:yyyyMMddHHmmss}{beforeExt}";
                    string beforePath = Path.Combine(beforeFolder, beforeImageName);

                    using (var stream = new FileStream(beforePath, FileMode.Create))
                    {
                        await dto.BeforeImage.CopyToAsync(stream);
                    }
                }

                // Save After Image
                if (dto.AfterImage != null && dto.AfterImage.Length > 0)
                {
                    string afterExt = Path.GetExtension(dto.AfterImage.FileName);
                    afterImageName = $"After_{dto.TransId}_{DateTime.Now:yyyyMMddHHmmss}{afterExt}";
                    string afterPath = Path.Combine(afterFolder, afterImageName);

                    using (var stream = new FileStream(afterPath, FileMode.Create))
                    {
                        await dto.AfterImage.CopyToAsync(stream);
                    }
                }

                return await _repo.UpdateMouldCheckSheet(dto, beforeImageName, afterImageName);
            }
            catch (Exception ex)
            {
                return $"Exception: {ex.Message} | Inner: {ex.InnerException?.Message}";
            }
        }
    }
}
