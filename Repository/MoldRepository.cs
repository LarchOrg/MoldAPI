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
    }
}
