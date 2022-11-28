using Microsoft.EntityFrameworkCore;
using ScheduleService.Entity;
using ScheduleService.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleService.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ScheduleContext _dbContext;

        public ScheduleRepository(ScheduleContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Meeting> GetMeetingAsync(int id)
        {
            return await _dbContext.Meetings.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Meeting>> GetMeetingsAsync()
        {
            return await _dbContext.Meetings.ToListAsync();
        }

        public async Task<int> CreateMeetingAsync(Meeting meeting)
        {
            await _dbContext.Meetings.AddAsync(meeting);
            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(meeting.Id);
        }

        public async Task UpdateMeetingAsync(Meeting meeting)
        {
            _dbContext.Meetings.Update(meeting);
            await _dbContext.SaveChangesAsync();
        }
    }
}