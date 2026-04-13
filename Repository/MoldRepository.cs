using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MoldApi.Data;
using MoldApi.DTOs;
using MoldApi.Entities;
using MoldApi.Interfaces;
using System;
using System.Data;
using static MoldApi.Repository.MoldRepository;

namespace MoldApi.Repository
{
    public class MoldRepository : IMoldRepository
    {
        private readonly AppDbContext _context;

        public MoldRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Mold>> GetAll()
        {
            return await _context.Molds.ToListAsync();
        }

        public async Task<Mold> GetById(int id)
        {
            return await _context.Molds.FindAsync(id);
        }

        public async Task<List<MoldDropdownDto>> GetMoldDropdown()
        {
            return await _context.Set<MoldDropdownDto>()
                .FromSqlRaw("EXEC Api_GetMoldDropdown")
                .ToListAsync();
        }
        public async Task<List<MoldDropdownDto>> GetMoldImgDropdown()
        {
            return await _context.Set<MoldDropdownDto>()
                .FromSqlRaw("EXEC API_pr_fetch_Imagespec_mst1")
                .ToListAsync();
        }
        public async Task<List<MoldPlanCheckSheetFetchDto>> GetPMCheckSheetFetch()
        {
            return await _context.Set<MoldPlanCheckSheetFetchDto>()
                .FromSqlRaw("EXEC API_pr_fetch_mould_PM_CheckSheet")
                .ToListAsync();
        }
        public async Task<List<MoldPlanCheckSheetFetchDto>> GetDailyCheckSheetFetch()
        {
            return await _context.Set<MoldPlanCheckSheetFetchDto>()
                .FromSqlRaw("EXEC API_pr_fetch_mould_Daily_PM_schedule")
                .ToListAsync();
        }
        public async Task<List<PMMouldMasterFetchDto>> GetMouldMstFetch()
        {
            return await _context.Set<PMMouldMasterFetchDto>()
                .FromSqlRaw("EXEC Api_pr_fetch_mould_mst")
                .ToListAsync();
        }
        public async Task<List<CheckAreaDto>> GetMoldCheckArea()
        {
            return await _context.Set<CheckAreaDto>()
                .FromSqlRaw("EXEC API_Pr_Fetch_Cheack_Areas_Drp")
                .ToListAsync();
        }
        public async Task<List<CurrentStsDto>> GetCurrentSts()
        {
            return await _context.Set<CurrentStsDto>()
                .FromSqlRaw("EXEC API_pr_fetch_currentstatus")
                .ToListAsync();
        }

        public async Task<List<CheckPointDto>> GetMoldCheckPoint()
        {
            return await _context.Set<CheckPointDto>()
                .FromSqlRaw("EXEC API_Pr_Fetch_Maintenance_CheckPoint_Drp")
                .ToListAsync();
        }
        public async Task<List<PartNoDrpDto>> GetPartNo()
        {
            return await _context.Set<PartNoDrpDto>()
                .FromSqlRaw("EXEC API_pr_fetch_PartNo")
                .ToListAsync();
        }

        public async Task<List<ReqConditionDto>> GetMoldReqCondition()
        {
            return await _context.Set<ReqConditionDto>()
                .FromSqlRaw("EXEC API_Pr_Fetch_Req_Condition_Drp")
                .ToListAsync();
        }

        public async Task<List<CheckMethodDto>> GetMoldCheckMethod()
        {
            return await _context.Set<CheckMethodDto>()
                .FromSqlRaw("EXEC API_Pr_Fetch_Maintenance_CheckMethod_Drp")
                .ToListAsync();
        }
        public async Task<List<PMMouldSpecFetchDto>> GetMoldSpecFetch()
        {
            return await _context.Set<PMMouldSpecFetchDto>()
                .FromSqlRaw("EXEC API_pr_fetch_Maintenance_Spec_Entry_mst")
                .ToListAsync();
        }
        public async Task<List<MoldDropdownDto>> GetPMDropdown()
        {
            return await _context.Set<MoldDropdownDto>()
                .FromSqlRaw("EXEC API_pr_fetch_pmfreq_drp")
                .ToListAsync();
        }
        public async Task<List<MouldPMPlanDto>> GetPMPlanDetails()
        {
            return await _context.Set<MouldPMPlanDto>()
                .FromSqlRaw("EXEC API_pr_fetch_mould_PM_schedule")
                .ToListAsync();
        }

        public async Task<string> UpdateSpecEnrty(UpdateSpecEntrybyIdDto dto)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    @"EXEC API_pr_update_Specc_entry_Mst               
                    @iId ,  
                    @iPmfreq ,   
                    @iCheckPoint ,                                                       
                    @iCheckMethod ,   
                    @iCheckAreas ,  
                    @iRequiredCondition ,  
                    @iImageId ,                                                                    
                    @iOrderby ,                                              
                    @iUpdatedBy ",

                    new SqlParameter("@iId", dto.Id),
                    new SqlParameter("@iPmfreq", dto.PMFreqId),
                    new SqlParameter("@iCheckPoint", dto.CheckPointId),
                    new SqlParameter("@iCheckMethod", dto.CheckMethodId),

                    new SqlParameter("@iCheckAreas", dto.CheckAreaId),
                    new SqlParameter("@iRequiredCondition", dto.ReqConditionId),
                    new SqlParameter("@iImageId", dto.ImgId),
                    new SqlParameter("@iOrderby", dto.OrderBy),

                    new SqlParameter("@iUpdatedBy", dto.UpdateBy )
                );

                return "Updated Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> UpdateMoldMst(UpdateMouldMstDto dto)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    @"EXEC API_pr_update_Mould_mst @iId,
                @vCode,
                @vName,
                @vSize,
                @nCavity,
                @nOpeningShot,
                @nLifeShot,
                @nCurrentShot,
                @vLocation,
                @iItem,
                @dUsedFrom,
                @vCategory,
                
                @iPMFreqDays,
                @iPMFreqShots,
                @vColor,
                @vSupplier,
                @vMakerSupplier,
                @vRemarks,
                @iUpdatedBy,
                @vBarcode,
                @vDirection",

                    new SqlParameter("@iId", dto.Id),
                    new SqlParameter("@vCode", dto.Code ?? (object)DBNull.Value),
                    new SqlParameter("@vName", dto.Name ?? (object)DBNull.Value),
                    new SqlParameter("@vSize", dto.Size ?? (object)DBNull.Value),

                    new SqlParameter("@nCavity", dto.Cavity),
                    new SqlParameter("@nOpeningShot", dto.OpeningShot),
                    new SqlParameter("@nLifeShot", dto.LifeShot),
                    new SqlParameter("@nCurrentShot", dto.CurrentShot),

                    new SqlParameter("@vLocation", dto.Location ?? (object)DBNull.Value),
                    new SqlParameter("@iItem", dto.Item),

                    new SqlParameter("@dUsedFrom", dto.UsedFrom),

                    new SqlParameter("@vCategory", dto.Category ?? (object)DBNull.Value),
                    //new SqlParameter("@vPMFreq", dto.PMFreq),

                    new SqlParameter("@iPMFreqDays", dto.PMFreqDays),
                    new SqlParameter("@iPMFreqShots", dto.PMFreqShots),

                    new SqlParameter("@vColor", dto.Color ?? (object)DBNull.Value),
                    new SqlParameter("@vSupplier", dto.Supplier ?? (object)DBNull.Value),
                    new SqlParameter("@vMakerSupplier", dto.MakerSupplier ?? (object)DBNull.Value),

                    new SqlParameter("@vRemarks", dto.Remarks ?? (object)DBNull.Value),

                    new SqlParameter("@iUpdatedBy", dto.UpdatedBy),

                    new SqlParameter("@vBarcode", dto.Barcode ?? (object)DBNull.Value),
                    new SqlParameter("@vDirection", dto.Direction ?? (object)DBNull.Value)
                );

                return "Updated Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> InsertMoldMst(InsertMouldMstDto dto)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    @"EXEC Api_pr_insert_Mould_mst 
                @vCode,
                @vName,
                @vSize,
                @nCavity,
                @nOpeningShot,
                @nLifeShot,
                @nCurrentShot,
                @vLocation,
                @iItem,
                @dUsedFrom,
                @vCategory,
                @iPMFreqDays,
                @iPMFreqShots,
                @vColor,
                @vSupplier,
                @vMakerSupplier,
                @vRemarks,
                @iCreatedBy,
                @vBarcode,
                @vDirection",

                    new SqlParameter("@vCode", dto.Code ?? (object)DBNull.Value),
                    new SqlParameter("@vName", dto.Name ?? (object)DBNull.Value),
                    new SqlParameter("@vSize", dto.Size ?? (object)DBNull.Value),

                    new SqlParameter("@nCavity", dto.Cavity),
                    new SqlParameter("@nOpeningShot", dto.OpeningShot),
                    new SqlParameter("@nLifeShot", dto.LifeShot),
                    new SqlParameter("@nCurrentShot", dto.CurrentShot),

                    new SqlParameter("@vLocation", dto.Location ?? (object)DBNull.Value),
                    new SqlParameter("@iItem", dto.Item),

                    new SqlParameter("@dUsedFrom", dto.UsedFrom),

                    new SqlParameter("@vCategory", dto.Category ?? (object)DBNull.Value),

                    //new SqlParameter("@vPMFreq", dto.PMFreq),

                    new SqlParameter("@iPMFreqDays", dto.PMFreqDays),
                    new SqlParameter("@iPMFreqShots", dto.PMFreqShots),

                    new SqlParameter("@vColor", dto.Color ?? (object)DBNull.Value),
                    new SqlParameter("@vSupplier", dto.Supplier ?? (object)DBNull.Value),
                    new SqlParameter("@vMakerSupplier", dto.MakerSupplier ?? (object)DBNull.Value),

                    new SqlParameter("@vRemarks", dto.Remarks ?? (object)DBNull.Value),

                    new SqlParameter("@iCreatedBy", dto.CreatedBy),

                    new SqlParameter("@vBarcode", dto.Barcode ?? (object)DBNull.Value),
                    new SqlParameter("@vDirection", dto.Direction ?? (object)DBNull.Value)
                );

                return "Inserted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> InsertCheckMasterAsync(CheckInsertDto dto)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC API_pr_insert_check_master @vType, @vName, @iCreatedBy",
                    new SqlParameter("@vType", dto.Type),
                    new SqlParameter("@vName", dto.Name),
                    new SqlParameter("@iCreatedBy", dto.CreatedBy)
                );

                return "Inserted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> InsertMoldPMSchedule(CreateMoldPMScheduleDto dto)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC API_Insert_Mould_PM_Schedule @dDate, @iMouldId, @iPMFreq, @iCreatedBy",
                    new SqlParameter("@dDate", dto.dDate),
                    new SqlParameter("@iMouldId", dto.iMouldId),
                    new SqlParameter("@iPMFreq", dto.iPMFreq),
                    new SqlParameter("@iCreatedBy", dto.iCreatedBy)
                );

                return "Inserted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> CreateCheckSheet(CreateCheckSheetDto dto)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC API_Insert_Create_MouldCheckSheet_Entry @iReportNo, @vPreparedBy, @iCreatedBy",
                    new SqlParameter("@iReportNo", dto.ReportNo),
                    new SqlParameter("@vPreparedBy", dto.PrepareBy),
                    new SqlParameter("@iCreatedBy", dto.CreatedBy)
                );

                return "CheckSheet Created!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> InsertMaintenanceSpecEntry(CreateMaintenanceSpecEntryDto dto)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC pr_insert_Maintenance_Spec_Entry_Mst @iMouldMachineId,  @iCheckPoint, @iCheckMethod, @iPMFreq, @iImgId, @iOrderby, @iCreatedBy, @iCheckAreaId, @iResultId",
                    
                    new SqlParameter("@iMouldMachineId", dto.MouldMachineId),
                    new SqlParameter("@iCheckPoint", dto.CheckPoint),
                    new SqlParameter("@iCheckMethod", dto.CheckMethod),
                    new SqlParameter("@iPMFreq", dto.PMFreq),
                    new SqlParameter("@iImgId", dto.ImgId),
                    new SqlParameter("@iOrderby", dto.Orderby),
                    new SqlParameter("@iCreatedBy", dto.CreatedBy),
                    new SqlParameter("@iCheckAreaId", dto.CheckAreaId),
                    new SqlParameter("@iResultId", dto.ResultId)
                );

                return "Inserted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message; // captures RAISERROR from SP e.g. "This Orderby No Already Exists!"
            }
        }

        public async Task<List<MouldPMReportDto>> GetPMMoldReport(DateOnly fromDate, DateOnly toDate)
        {
            var from = new SqlParameter("@vFromDt", fromDate);
            var to = new SqlParameter("@vToDt", toDate);  // was @dToDate, must match SP param name

            var resultList = await _context.MouldPMReportDto
                .FromSqlRaw("EXEC API_pr_fetch_lerp_Mould_CheckSheet_Summary @vFromDt, @vToDt", from, to)
                .AsNoTracking()
                .ToListAsync();

            return resultList;
        }
        public async Task<MaintenanceSpecEntrybyIdDto> GetSpecEntryById(int id)
        {
            var param = new SqlParameter("@iID", id);

            // Execute SP and fetch results
            var resultList = await _context.MaintenanceSpecEntrybyIdDto
                .FromSqlRaw("EXEC API_pr_fetch_Maintenance_Spec_Entry_mst_byId @iID", param)
                .AsNoTracking()    
                .ToListAsync();  

            // Pick the first record
            var result = resultList.FirstOrDefault();

            return result;
        }
        public async Task<List<MouldReportDto>> GetCheckSheetDetails(int id)
        {
            var param = new SqlParameter("@iReportNo", id);

            var resultList = await _context.MouldReportDto
                .FromSqlRaw("EXEC API_pr_fetch_MouldCheckSheet_Entry @iReportNo", param)
                .AsNoTracking()
                .ToListAsync();

            return resultList;
        }
        public async Task<List<DailyCheckSheetDto>> GetDailyCheckSheetDetails(int id)
        {
            var param = new SqlParameter("@iReportNo", id);

            var resultList = await _context.DailyCheckSheetDto
                .FromSqlRaw("EXEC API_pr_fetch_Daily_MouldCheckSheet_Entry @iReportNo", param)
                .AsNoTracking()
                .ToListAsync();

            return resultList;
        }
        public async Task<MouldMstByIdDto> GetMouldMstById(int id)
        {
            var param = new SqlParameter("@Id", id);

            // Execute SP and fetch results
            var resultList = await _context.MouldMstByIdDto
                .FromSqlRaw("EXEC API_Pr_Fetch_mould_mst_ById @Id", param)
                .AsNoTracking()    
                .ToListAsync();  

            // Pick the first record
            var result = resultList.FirstOrDefault();

            return result;
        }
        public async Task<MoldPMScheduleIdDto> GetPMScheduleById(int id)
        {
            var param = new SqlParameter("@Id", id);

            // Execute SP and fetch results
            var resultList = await _context.MoldPMScheduleIdDto
                .FromSqlRaw("EXEC API_fetch_mould_PM_scheduleBy_id @Id", param)
                .AsNoTracking()    
                .ToListAsync();  

            // Pick the first record
            var result = resultList.FirstOrDefault();

            return result;
        }

        public async Task<string> UpdateMoldPMSchedule(UpdateMoldPMScheduleDto dto)
    {
        try
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC Api_update_MouldPm_Targetdate @Id, @dDate",
                new SqlParameter("@Id", dto.Id),
                new SqlParameter("@dDate", dto.dDate)
            );

            return "Updated Successfully";
        }
        catch (Exception ex)
        {
            return ex.Message; // will capture RAISERROR from SP
        }
    }
        public async Task<string> DeletePMPlan(int id)
    {
        try
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC API_Pr_Delete_mouldPrev_plan @iID",
                new SqlParameter("@iID", id)
            );

            return "Deleted Successfully";
        }
        catch (Exception ex)
        {
            return ex.Message; // will capture RAISERROR from SP
        }
    }
        public async Task<string> DeletePMSpec(int id)
    {
        try
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC API_pr_delete_Maintenance_Spec_Entry @iID",
                new SqlParameter("@iID", id)
            );

            return "Deleted Successfully";
        }
        catch (Exception ex)
        {
            return ex.Message; // will capture RAISERROR from SP
        }
    }

        public async Task<string> UpdateMouldCheckSheet(UpdateMouldCheckSheetDto dto, string? beforeImageName, string? afterImageName)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    @"EXEC pr_update_mould_checksheet 
                @iTransId, 
                @vCurrentStatus, 
                @vActiontaken, 
                @BeforeImageName, 
                @AfterImageName, 
                @vRemarks",
                    new SqlParameter("@iTransId", dto.TransId),
                    new SqlParameter("@vCurrentStatus", dto.CurrentStatus ?? (object)DBNull.Value),
                    new SqlParameter("@vActiontaken", dto.ActionTaken ?? (object)DBNull.Value),
                    new SqlParameter("@BeforeImageName", beforeImageName ?? (object)DBNull.Value),
                    new SqlParameter("@AfterImageName", afterImageName ?? (object)DBNull.Value),
                    new SqlParameter("@vRemarks", dto.Remarks ?? (object)DBNull.Value)
                );

                return "Updated Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        public async Task<string> UpdateMouldCheckSheetEntry(UpdateMouldCheckSheetEntryDto dto)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    @"EXEC Pr_Update_Mould_CheckSheet_Entry 
                @iReportNo,
                @vpreparedby,
                @vcheckedby,
                @vapprovedby,
                @iCreatedBy",
                    new SqlParameter("@iReportNo", dto.ReportNo),
                    new SqlParameter("@vpreparedby", dto.PreparedBy ?? (object)DBNull.Value),
                    new SqlParameter("@vcheckedby", dto.CheckedBy ?? (object)DBNull.Value),
                    new SqlParameter("@vapprovedby", dto.ApprovedBy ?? (object)DBNull.Value),
                    new SqlParameter("@iCreatedBy", dto.CreatedBy)
                );

                return "Updated Successfully";
            }
            catch (Exception ex)
            {
                return $"Exception: {ex.Message} | Inner: {ex.InnerException?.Message}";
            }
        }

    }
}
