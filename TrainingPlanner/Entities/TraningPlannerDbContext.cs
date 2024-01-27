using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace WebApplication1.Entities;

public class TrainingPlannerDbContext: DbContext

{
    private string _connectionString = String.Empty;
    protected TrainingPlannerDbContext(DbSet<Exercises> exercises)
    {
        Exercises = exercises;
    }

    public DbSet<Exercises> Exercises { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercises>();

    }

    protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
    {
        contextOptionsBuilder.UseSqlServer(_connectionString);
    }
}