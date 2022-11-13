using Microsoft.EntityFrameworkCore;
using ScheduleService.Entity.Models;
using System.Reflection;

namespace ScheduleService.Entity
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}