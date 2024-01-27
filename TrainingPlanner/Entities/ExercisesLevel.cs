namespace WebApplication1.Entities;

public class ExercisesLevel
{
    public ExercisesLevel(Gender gender)
    {
        Gender = gender;
    }

    public virtual Gender Gender { get; set; }
}