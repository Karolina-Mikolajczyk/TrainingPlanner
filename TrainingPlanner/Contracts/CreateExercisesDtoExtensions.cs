using TrainingPlanner.Entities;
using TrainingPlanner.FileImport;

namespace TrainingPlanner.Contracts;

public static class CreateExercisesDtoExtensions
{
    public static Exercises ToExercise(this CreateExercisesDto dto)
    {
        return new Exercises
        {
            Name = dto.Name,
            Description = dto.Description
        };
    }
}

public static class ExercisesModelExtension
{
    public static IEnumerable<Exercises> ToEntities(this IEnumerable<ExerciseModel> models)
    {
        return models.Select(model => new Exercises { Description = model.Description, Name = model.Name }).ToList();
    }
}