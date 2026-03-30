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
        }


        public DbSet<PMMouldSpecFetchDto> PMMouldSpecFetchDtos { get; set; }
        public DbSet<CheckAreaDto> CheckAreaDtos { get; set; }
        public DbSet<CheckMethodDto> CheckMethodDtos { get; set; }
        public DbSet<CheckPointDto> CheckPointDtos { get; set; }
        public DbSet<ReqConditionDto> ReqConditionDtos { get; set; }
        public DbSet<MoldPMScheduleIdDto> MoldPMScheduleIdDto { get; set; }
    }
}
