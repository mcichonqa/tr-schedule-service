using System;

namespace ScheduleService.Contract
{
    public class MeetingCreatedEvent
    {
        public int Id { get; init; }
        public DateTime CreateDate { get; init; }
        public DateTime StartMeetingDate { get; init; }
        public int ClientId { get; init; }
        public string MeetingTopic { get; init; }
        public bool IsScheduled { get; init; }

        public MeetingCreatedEvent()
        {
        }

        public MeetingCreatedEvent(int id, DateTime createDate, DateTime startMeetingDate, int clientId, string meetingTopic, bool isScheduled)
        {
            Id = id;
            CreateDate = createDate;
            StartMeetingDate = startMeetingDate;
            ClientId = clientId;
            MeetingTopic = meetingTopic;
            IsScheduled = isScheduled;
        }
    }
}