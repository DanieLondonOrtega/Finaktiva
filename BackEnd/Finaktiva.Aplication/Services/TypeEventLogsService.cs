using AutoMapper;
using Finaktiva.Aplication.Dtos;
using Finaktiva.Aplication.Interfaces;
using Finaktiva.Domain.Entities;
using Finaktiva.Infrastructur.DataAccess.Repository;

namespace Finaktiva.Aplication.Services
{
    public class TypeEventLogsService : ITypeEventLogsService
    {
        private readonly IRepositoryBase<TypeEventLogs> _typeEventLogsRepository;
        private readonly IMapper _mapper;
        public TypeEventLogsService(IRepositoryBase<TypeEventLogs> typeEventLogsRepository, IMapper mapper)
        {
            _typeEventLogsRepository = typeEventLogsRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TypeEventLogsDto>> GetAll()
        {
            var result = await _typeEventLogsRepository.GetAll();
            return _mapper.Map<IEnumerable<TypeEventLogsDto>>(result);
        }
    }
}
