using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace WebApplication1.Entities;

public class TrainingPlannerDbContext: DbContext

{
    private string _connectionString = String.Empty;
    protected TrainingPlannerDbContext(DbSet<Gender> genders, DbSet<ExercisesLevel> exercisesLevels)
    {
        Genders = genders;
        ExercisesLevels = exercisesLevels;
    }

    public TrainingPlannerDbContext(DbContextOptions options, DbSet<Gender> genders, DbSet<ExercisesLevel> exercisesLevels) : base(options)
    {
        Genders = genders;
        ExercisesLevels = exercisesLevels;
    }

    public DbSet<Gender> Genders { get; set; }
    public DbSet<ExercisesLevel> ExercisesLevels { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gender>();


        modelBuilder.Entity<ExercisesLevel>();

    }

    protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
    {
        contextOptionsBuilder.UseSqlServer(_connectionString);
    }
}