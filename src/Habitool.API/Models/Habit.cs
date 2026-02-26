namespace Habitool.API.Models
{
    public class Habit
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Frequency { get; set; } = "daily"; // daily, weekly, etc.
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public bool IsGood { get; set; } = true;
        public string? UserId { get; set; } // optional user identifier

        // parameterless ctor for serialization
        public Habit() { }

        public Habit(int id, string title, string description, string frequency, DateTime startDate, bool isGood, string? userId = null)
        {
            Id = id;
            Title = title;
            Description = description;
            Frequency = frequency;
            StartDate = startDate;
            IsGood = isGood;
            UserId = userId;
        }
    }
}