using Microsoft.EntityFrameworkCore;
using MoldApi.DTOs;
using MoldApi.Entities;
using System.Collections.Generic;
namespace MoldApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Tables
        public DbSet<Mold> Molds { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoldDropdownDto>().HasNoKey();
            modelBuilder.Entity<PMMouldSpecFetchDto>().HasNoKey();
            modelBuilder.Entity<MouldPMPlanDto>().HasNoKey();
            modelBuilder.Entity<MoldPMScheduleIdDto>().HasNoKey();
            modelBuilder.Entity<CheckAreaDto>().HasNoKey();
            modelBuilder.Entity<CheckMethodDto>().HasNoKey();
            modelBuilder.Entity<CheckPointDto>().HasNoKey();
            modelBuilder.Entity<ReqConditionDto>().HasNoKey();
            modelBuilder.Entity<PartNoDrpDto>().HasNoKey();
            modelBuilder.Entity<MoldPlanCheckSheetFetchDto>().HasNoKey();
            modelBuilder.Entity<PMMouldMasterFetchDto>().HasNoKey();
            modelBuilder.Entity<MouldMstByIdDto>().HasNoKey();
            modelBuilder.Entity<MaintenanceSpecEntrybyIdDto>().HasNoKey();
            modelBuilder.Entity<MouldReportDto>().HasNoKey();
        }


        public DbSet<MoldPlanCheckSheetFetchDto> MoldPlanCheckSheetFetchDto { get; set; }
        public DbSet<MouldReportDto> MouldReportDto { get; set; }
        public DbSet<MaintenanceSpecEntrybyIdDto> MaintenanceSpecEntrybyIdDto { get; set; }
        public DbSet<MouldMstByIdDto> MouldMstByIdDto { get; set; }
        public DbSet<PMMouldMasterFetchDto> PMMouldMasterFetchDto { get; set; }
        public DbSet<PMMouldSpecFetchDto> PMMouldSpecFetchDtos { get; set; }
        public DbSet<CheckAreaDto> CheckAreaDtos { get; set; }
        public DbSet<CheckMethodDto> CheckMethodDtos { get; set; }
        public DbSet<CheckPointDto> CheckPointDtos { get; set; }
        public DbSet<ReqConditionDto> ReqConditionDtos { get; set; }
        public DbSet<PartNoDrpDto> PartNoDrpDto { get; set; }
        public DbSet<MoldPMScheduleIdDto> MoldPMScheduleIdDto { get; set; }
    }
}
