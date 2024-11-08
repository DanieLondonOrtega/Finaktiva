using AutoMapper;
using Finaktiva.Aplication.Dtos;
using Finaktiva.Aplication.Interfaces;
using Finaktiva.Domain.Entities;
using Finaktiva.Infrastructur.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;

namespace Finaktiva.Aplication.Services
{
    public class EventLogsService : IEventLogsService
    {
        private readonly IRepositoryBase<EventLogs> _eventLogsRepository;
        private readonly IMapper _mapper;
        public EventLogsService(IRepositoryBase<EventLogs> eventLogsRepository, IMapper mapper)
        {
            _eventLogsRepository = eventLogsRepository;
            _mapper = mapper;
        }
        public async Task<EventLogsDto> Get(int id)
        {
            var result = _eventLogsRepository.GetById(x => x.Id == id, y => y.TypeEventLogs).Result;
            return _mapper.Map<EventLogsDto>(result);
        }

        public async Task<IEnumerable<EventLogsDto>> GetAll()
        {
            var result = _eventLogsRepository.GetAll().Result.Include("TypeEventLogs").OrderByDescending(x => x.Id).ToList();
            return _mapper.Map<IEnumerable<EventLogsDto>>(result);
        }

        public async Task<bool> Post(EventLogsDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Event Log is Requerid");

            var obj = _mapper.Map<EventLogs>(entity);
            return _eventLogsRepository.Add(obj);
        }
    }
}
