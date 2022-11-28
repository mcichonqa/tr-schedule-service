using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Api.Models;
using ScheduleService.Application;
using ScheduleService.Contract;
using ScheduleService.Entity.Models;
using System.Threading.Tasks;

namespace ScheduleService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleServices _scheduleServices;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public ScheduleController(IScheduleServices scheduleServices, IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _scheduleServices = scheduleServices;
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
        }

        [HttpGet("meeting/{id}")]
        public async Task<IActionResult> GetMeeting(int id)
        {
            Meeting meeting = await _scheduleServices.GetMeetingAsync(id);
            MeetingDto result = _mapper.Map<MeetingDto>(meeting);

            return Ok(result);
        }

        [HttpPost("createMeeting")]
        public async Task<IActionResult> CreateMeeting([FromBody] MeetingDto meeting)
        {
            Meeting result = _mapper.Map<Meeting>(meeting);
            int id = await _scheduleServices.CreateMeetingAsync(result);

            var @event = new MeetingCreatedEvent()
            {
                Id = id,
                CreateDate = result.CreateDate,
                StartMeetingDate = result.StartMeetingDate,
                ClientId = result.ClientId,
                MeetingTopic = result.MeetingTopic,
                IsScheduled = result.IsScheduled
            };

            await _publishEndpoint.Publish(@event);

            return Created($"~/api/schedule/{@event.Id}", @event);
        }

        [HttpPut("cancelMeeting/{meetingId}")]
        public async Task<IActionResult> CancelMeeting(int meetingId)
        {
            await _scheduleServices.CancelMeeting(meetingId);
            Meeting meeting = await _scheduleServices.GetMeetingAsync(meetingId);

            var @event = new MeetingCanceledEvent(){ Id = meeting.Id };

            await _publishEndpoint.Publish(@event);

            return Ok();
        }
    }
}