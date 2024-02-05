namespace TrainingPlanner.Domain;

public record TrainingPlan
{
    private readonly Gender _gender;
    private readonly ExercisesLevel _level;

    public TrainingPlan(Gender gender, ExercisesLevel level)
    {
        _gender = gender;
        _level = level;
    }

    public IEnumerable<DayOfExercise> GenerateExercises()
    {
        return Enumerable.Empty<DayOfExercise>();
    }
}