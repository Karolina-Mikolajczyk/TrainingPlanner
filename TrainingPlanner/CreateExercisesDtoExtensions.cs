
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1;

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