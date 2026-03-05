namespace Habitool.API.Models
{
    public class LogEntry
    {
        public int Id { get; set; }
        public int HabitId { get; set; }
        public DateTime Timestamp { get; set; }

        public LogEntry() { }

        public LogEntry(int id, int habitId, DateTime timestamp)
        {
            Id = id;
            HabitId = habitId;
            Timestamp = timestamp;
        }
    }
}