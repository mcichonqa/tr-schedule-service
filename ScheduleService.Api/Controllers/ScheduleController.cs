using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Api.Models;
using ScheduleService.Contract;
using ScheduleService.Entity.Models;
using ScheduleService.Repository;
using System.Threading.Tasks;

namespace ScheduleService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IMeetingRepository _meetingService;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public ScheduleController(IMeetingRepository meetingService, IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _meetingService = meetingService;
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
        }

        [HttpGet("meeting/{id}")]
        public async Task<IActionResult> GetMeeting(int id)
        {
            Meeting meeting = await _meetingService.GetMeetingAsync(id);
            MeetingDto result = _mapper.Map<MeetingDto>(meeting);

            return Ok(result);
        }

        [HttpPost("createMeeting")]
        public async Task<IActionResult> CreateMeeting([FromBody] MeetingDto meeting)
        {
            Meeting result = _mapper.Map<Meeting>(meeting);

            int id = await _meetingService.CreateMeetingAsync(result);

            var @event = new MeetingCreatedEvent()
            {
                Id = id,
                CreateDate = result.CreateDate,
                StartMeetingDate = result.StartMeetingDate,
                ClientId = result.ClientId,
                MeetingTopic = result.MeetingTopic,
                HasSubscription = result.HasSubscription
            };

            await _publishEndpoint.Publish(@event);

            return Created($"~/api/schedule/{@event.Id}", @event);
        }
    }
}