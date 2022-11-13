using Microsoft.EntityFrameworkCore;
using ScheduleService.Entity;
using ScheduleService.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleService.Repository
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly ScheduleContext _dbContext;

        public MeetingRepository(ScheduleContext dbContext)
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
            await _dbContext.AddAsync(meeting);
            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(meeting.Id);
        }

        public Task CancelMeetingAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}