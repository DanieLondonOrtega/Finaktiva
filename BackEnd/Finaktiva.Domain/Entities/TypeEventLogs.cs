namespace Finaktiva.Domain.Entities
{
    public class TypeEventLogs
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<EventLogs> EventsLogs { get; set; }
    }
}
