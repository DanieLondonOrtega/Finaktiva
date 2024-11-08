namespace Finaktiva.Domain.Entities
{
    public class EventLogs
    {
        public int Id { get; set; }
        public int IdType { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }  
        public TypeEventLogs TypeEventLogs { get; set; }
    }
}
