
using WebApplication1.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TrainingPlannerDbContext>();
builder.Services.AddScoped<ExerciseSeeder>();


var app = builder.Build();

// Configure the HTTP request pipeline.
using var serviceScope = app.Services.CreateScope();
var exerciseSeeder =serviceScope.ServiceProvider.GetRequiredService<ExerciseSeeder>();
exerciseSeeder.Seed();

if (app.Environment.IsDevelopment())
    
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();