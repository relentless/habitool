using Habitool.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorLocal", policyBuilder =>
    {
        policyBuilder
            .WithOrigins("http://localhost:5008", "https://localhost:7123", "http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowBlazorLocal");

// sample data for habits (mutable list)
var sampleHabits = new List<Habit>
{
    new Habit { Id = 1, Title = "Morning Run", Description = "Run 3 miles every morning", Frequency = "daily", StartDate = DateTime.UtcNow.AddDays(-30), IsGood = true },
    new Habit { Id = 2, Title = "Read Book", Description = "Read at least 30 minutes", Frequency = "daily", StartDate = DateTime.UtcNow.AddDays(-10), IsGood = true },
    new Habit { Id = 3, Title = "Meditate", Description = "Meditate for 10 minutes", Frequency = "daily", StartDate = DateTime.UtcNow.AddDays(-5), IsGood = true }
};

// sample log entries
var sampleLogs = new List<LogEntry>
{
    new LogEntry(1, 1, DateTime.UtcNow.AddDays(-1)),
    new LogEntry(2, 1, DateTime.UtcNow.AddDays(-2)),
    new LogEntry(3, 2, DateTime.UtcNow.AddDays(-1))
};

// simple insights strings
var sampleInsights = new[]
{
    "You're doing great! Keep up the streak.",
    "Consider doing your morning run earlier."
};

// habit CRUD endpoints
app.MapGet("/api/habits", () => sampleHabits)
   .WithName("GetHabits")
   .WithOpenApi();

app.MapPost("/api/habits", (Habit habit) =>
{
    var newId = sampleHabits.Any() ? sampleHabits.Max(h => h.Id) + 1 : 1;
    habit.Id = newId;
    sampleHabits.Add(habit);
    return Results.Created($"/api/habits/{newId}", habit);
})
.WithName("CreateHabit");

app.MapPut("/api/habits/{id}", (int id, Habit update) =>
{
    var idx = sampleHabits.FindIndex(h => h.Id == id);
    if (idx == -1) return Results.NotFound();
    update.Id = id;
    sampleHabits[idx] = update;
    return Results.NoContent();
})
.WithName("UpdateHabit");

app.MapDelete("/api/habits/{id}", (int id) =>
{
    var removed = sampleHabits.RemoveAll(h => h.Id == id);
    return removed > 0 ? Results.NoContent() : Results.NotFound();
})
.WithName("DeleteHabit");

app.MapGet("/api/habits/{id}", (int id) =>
{
    var habit = sampleHabits.FirstOrDefault(h => h.Id == id);
    return habit is not null ? Results.Ok(habit) : Results.NotFound();
})
.WithName("GetHabitById")
.WithOpenApi();

// logging endpoints
app.MapPost("/api/logs", (LogEntry entry) =>
{
    var newId = sampleLogs.Any() ? sampleLogs.Max(l => l.Id) + 1 : 1;
    var created = entry with { Id = newId };
    sampleLogs.Add(created);
    return Results.Created($"/api/logs/{created.Id}", created);
});

app.MapGet("/api/logs/{habitId}", (int habitId) =>
{
    var logsForHabit = sampleLogs.Where(l => l.HabitId == habitId).ToArray();
    return Results.Ok(logsForHabit);
});

app.MapGet("/api/statistics/{habitId}", (int habitId) =>
{
    var count = sampleLogs.Count(l => l.HabitId == habitId);
    var stats = new Statistics(habitId, count, count > 0 ? 1 : 0);
    return Results.Ok(stats);
});

app.MapGet("/api/insights", () => Results.Ok(sampleInsights));

app.Run();


record LogEntry(int Id, int HabitId, DateTime Timestamp);

record Statistics(int HabitId, int TotalLogs, int CurrentStreak);
