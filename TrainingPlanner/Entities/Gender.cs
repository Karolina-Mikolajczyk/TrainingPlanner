namespace WebApplication1.Entities;

public class Gender
{
    public Gender(List<ExercisesLevel> exercises)
    {
        Exercises = exercises;
    }

    public virtual List<ExercisesLevel> Exercises { get; set; }
}