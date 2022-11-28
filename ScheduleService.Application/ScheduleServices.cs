using ScheduleService.Entity.Models;
using ScheduleService.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleService.Application
{
    public class ScheduleServices : IScheduleServices
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleServices(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<Meeting> GetMeetingAsync(int id)
        {
            return await _scheduleRepository.GetMeetingAsync(id);
        }

        public async Task<List<Meeting>> GetMeetingsAsync()
        {
            return await _scheduleRepository.GetMeetingsAsync();
        }

        public async Task<int> CreateMeetingAsync(Meeting meeting)
        {
            return await _scheduleRepository.CreateMeetingAsync(meeting);
        }

        public async Task CancelMeeting(int meetingId)
        {
            Meeting meeting = await _scheduleRepository.GetMeetingAsync(meetingId);
            meeting.IsScheduled = false;

            await _scheduleRepository.UpdateMeetingAsync(meeting);
        }
    }
}