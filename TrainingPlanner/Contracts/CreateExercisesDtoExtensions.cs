using TrainingPlanner.Entities;

namespace TrainingPlanner.Contracts;

public static class CreateExercisesDtoExtensions
{
    public static Exercise ToExercise(this CreateExerciseDto dto)
    {
        return new Exercise
        {
            Name = dto.Name,
            Description = dto.Description
        };
    }
}