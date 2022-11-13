using ScheduleService.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleService.Repository
{
    public interface IMeetingRepository
    {
        Task<Meeting> GetMeetingAsync(int id);
        Task<List<Meeting>> GetMeetingsAsync();
        Task<int> CreateMeetingAsync(Meeting meeting);
        Task CancelMeetingAsync(int id);
    }
}