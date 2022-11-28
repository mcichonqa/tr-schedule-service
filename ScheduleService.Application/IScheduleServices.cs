using ScheduleService.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleService.Application
{
    public interface IScheduleServices
    {
        Task<Meeting> GetMeetingAsync(int id);
        Task<List<Meeting>> GetMeetingsAsync();
        Task<int> CreateMeetingAsync(Meeting meeting);
        Task CancelMeeting(int meetingId);
    }
}