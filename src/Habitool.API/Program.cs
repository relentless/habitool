var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// sample data for habits
var sampleHabits = new[]
{
    new Habit(1, "Morning Run", "Run 3 miles every morning"),
    new Habit(2, "Read Book", "Read at least 30 minutes"),
    new Habit(3, "Meditate", "Meditate for 10 minutes")
};

app.MapGet("/api/habits", () => sampleHabits)
   .WithName("GetHabits")
   .WithOpenApi();

app.MapGet("/api/habits/{id}", (int id) =>
{
    var habit = sampleHabits.FirstOrDefault(h => h.Id == id);
    return habit is not null ? Results.Ok(habit) : Results.NotFound();
})
.WithName("GetHabitById")
.WithOpenApi();

// leave weatherforecast for reference
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record Habit(int Id, string Title, string Description);

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
