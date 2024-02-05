using TrainingPlanner.Entities;

namespace TrainingPlanner.Contracts;
public static class ExercisesDtoExtensions
{
    public static void FromEntity(this ExercisesDto dto, Exercise entity)
    {
        dto.Id = entity.Id;
        dto.Item = entity.Name;
        dto.ShortDescription = entity.Description;
    }
}