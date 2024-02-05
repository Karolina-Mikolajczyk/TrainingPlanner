using TrainingPlanner.Entities;
using TrainingPlanner.FileImport;

namespace TrainingPlanner.Contracts;

public static class ExercisesModelExtension
{
    public static IEnumerable<Exercise> ToEntities(this IEnumerable<ExerciseModel> models)
    {
        return models.Select(model => new Exercise { Description = model.Description, Name = model.Name }).ToList();
    }
}