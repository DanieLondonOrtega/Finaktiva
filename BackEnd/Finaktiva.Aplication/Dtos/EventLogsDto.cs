using Finaktiva.Domain.Entities;

namespace Finaktiva.Aplication.Dtos
{
    public class EventLogsDto
    {
        public int Id { get; set; }
        public int IdType { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TypeEventLogsDto TypeEventLogs { get; set; }
    }
}
