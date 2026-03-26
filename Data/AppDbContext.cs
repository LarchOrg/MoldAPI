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
            modelBuilder.Entity<MouldPMPlanDto>().HasNoKey();
            modelBuilder.Entity<MoldPMScheduleIdDto>().HasNoKey();

        }

      

        public DbSet<MoldPMScheduleIdDto> MoldPMScheduleIdDto { get; set; }
    }
}
