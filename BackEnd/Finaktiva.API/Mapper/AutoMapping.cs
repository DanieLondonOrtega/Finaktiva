using Finaktiva.API.Models;
using Finaktiva.Aplication.Dtos;
using Finaktiva.Domain.Entities;

namespace Finaktiva.API.Mapper
{
    public class AutoMapping : AutoMapper.Profile
    {
        public AutoMapping()
        {
            CreateMap<EventLogsModel, EventLogsDto>().ReverseMap();
            CreateMap<EventLogsDto, EventLogs>().ReverseMap();
            CreateMap<TypeEventLogsDto, TypeEventLogs>().ReverseMap();
        }
    }
}
