using Microsoft.EntityFrameworkCore;

namespace TrainingPlanner.Entities;

public class TrainingPlannerDbContext: DbContext

{
    private readonly string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=TrainingPlannerDb;Trusted_Connection=True;";
 

    public DbSet<Exercise> Exercises { get; set; }
    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercise>()
            .Property((e => e.Id))
            .IsRequired();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
    {
        contextOptionsBuilder.UseSqlServer(_connectionString);
    }
}