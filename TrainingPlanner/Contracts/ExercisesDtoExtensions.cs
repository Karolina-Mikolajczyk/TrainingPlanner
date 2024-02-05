using TrainingPlanner.Entities;

namespace TrainingPlanner.Contracts;
// metoda rozszerzajaca ExercisesDto ktora wypełni ExercisesDto z przekazanej w parametrze encji Exercises (FromEntity(exercises))
public static class ExercisesDtoExtensions
{
    public static void FromEntity(this ExercisesDto dto, Exercises entity)
    {
        dto.Id = entity.Id;
        dto.Item = entity.Name;
        dto.ShortDescription = entity.Description;
    }
}