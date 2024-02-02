

using TrainingPlanner.FileImport;

namespace WebApplication1.Entities;

public class ExerciseSeeder
{
    private readonly TrainingPlannerDbContext _dbContext;

    public ExerciseSeeder(TrainingPlannerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        if (_dbContext.Database.CanConnect())
        {
            if (!_dbContext.Exercises.Any())
            {
                var exercises = GetExercises();
                _dbContext.Exercises.AddRange(exercises);
                _dbContext.SaveChanges();
            }
        }
    }

    private IEnumerable<Exercises> GetExercises()
    {
        var csvParser = new CsvParser();
        var models = csvParser.ParseAndSaveToDatabase(@"C:\Users\karol\Desktop\treningbiegacza\exercise1.csv");
        return models.ToEntities();
    }
}