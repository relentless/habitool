namespace Habitool.API.Models
{
    public class Statistics
    {
        public int HabitId { get; set; }
        public int TotalLogs { get; set; }
        public int CurrentStreak { get; set; }

        public Statistics() { }

        public Statistics(int habitId, int totalLogs, int currentStreak)
        {
            HabitId = habitId;
            TotalLogs = totalLogs;
            CurrentStreak = currentStreak;
        }
    }
}