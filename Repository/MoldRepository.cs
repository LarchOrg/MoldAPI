using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MoldApi.Data;
using MoldApi.DTOs;
using MoldApi.Entities;
using MoldApi.Interfaces;
using System;

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
        public async Task<List<CheckAreaDto>> GetMoldCheckArea()
        {
            return await _context.Set<CheckAreaDto>()
                .FromSqlRaw("EXEC API_Pr_Fetch_Cheack_Areas_Drp")
                .ToListAsync();
        }

        public async Task<List<CheckPointDto>> GetMoldCheckPoint()
        {
            return await _context.Set<CheckPointDto>()
                .FromSqlRaw("EXEC API_Pr_Fetch_Maintenance_CheckPoint_Drp")
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



        public async Task<MoldPMScheduleIdDto> GetPMScheduleById(int id)
        {
            var param = new SqlParameter("@Id", id);

            // Execute SP and fetch results
            var resultList = await _context.MoldPMScheduleIdDto
                .FromSqlRaw("EXEC API_fetch_mould_PM_scheduleBy_id @Id", param)
                .AsNoTracking()     // keyless entity, no tracking needed
                .ToListAsync();      // run SQL on server

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
}
}
