using AutoMapper;
using ScheduleService.Api.Models;
using ScheduleService.Entity.Models;
using System;

namespace ScheduleService.Api.Mapper.Profiles
{
    public class MeetingProfile : Profile
    {
        public MeetingProfile()
        {
            CreateMap<MeetingDto, Meeting>()
                .ForMember(x => x.MeetingTopic, y => y.MapFrom(y => y.MeetingTopic.ToString()));

            CreateMap<Meeting, MeetingDto>()
                .ForMember(x => x.MeetingTopic, y => y.MapFrom(y => Enum.Parse<MeetingTopic>(y.MeetingTopic)));
        }
    }
}