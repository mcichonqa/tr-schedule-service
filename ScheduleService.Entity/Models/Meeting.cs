using System;

namespace ScheduleService.Entity.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime StartMeetingDate { get; set; }
        public int ClientId { get; set; }
        public string MeetingTopic { get; set; }
        public bool HasSubscription { get; set; }
    }
}