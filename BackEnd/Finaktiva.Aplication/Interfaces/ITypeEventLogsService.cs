using Finaktiva.Aplication.Dtos;

namespace Finaktiva.Aplication.Interfaces
{
    public interface ITypeEventLogsService
    {
        Task<IEnumerable<TypeEventLogsDto>> GetAll();
    }
}
