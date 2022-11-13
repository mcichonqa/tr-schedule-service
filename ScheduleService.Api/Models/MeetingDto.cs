using System;

namespace ScheduleService.Api.Models
{
    public class MeetingDto
    {
        public DateTime CreateDate { get; set; }
        public int ClientId { get; set; }
        public DateTime StartMeetingDate { get; set; }
        public MeetingTopic MeetingTopic { get; set; }
        public bool HasSubscription { get; set; }
    }
}