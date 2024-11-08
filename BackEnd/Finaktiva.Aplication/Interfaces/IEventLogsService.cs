using Finaktiva.Aplication.Dtos;

namespace Finaktiva.Aplication.Interfaces
{
    public interface IEventLogsService
    {
        Task<bool> Post(EventLogsDto entity);
        Task<EventLogsDto> Get(int id);
        Task<IEnumerable<EventLogsDto>> GetAll();
    }
}
