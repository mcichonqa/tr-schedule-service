using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScheduleService.Entity.Models;

namespace ScheduleService.Entity.Configuration
{
    public class MeetingConfiguration : IEntityTypeConfiguration<Meeting>
    {
        public void Configure(EntityTypeBuilder<Meeting> builder)
        {
            builder
                .ToTable("Meetings")
                .HasKey("Id");

            builder
                .Property(e => e.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.
                 Property(x => x.CreateDate)
                .HasColumnType("datetime2")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.StartMeetingDate)
                .HasColumnType("datetime2")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.ClientId)
                .IsRequired();

            builder
                .Property(x => x.MeetingTopic)
                .IsRequired();

            builder
                .Property(x => x.IsScheduled)
                .IsRequired();
        }   
    }
}