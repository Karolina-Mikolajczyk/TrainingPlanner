namespace TrainingPlanner.Domain;

public record DayOfExercise(string Day, Dictionary<string, string[]> Exercises);