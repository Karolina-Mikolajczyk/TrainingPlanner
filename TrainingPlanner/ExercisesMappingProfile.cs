using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using WebApplication1.Entities;

namespace WebApplication1;

public class ExercisesMappingProfile: Profile
{
    public ExercisesMappingProfile()
    {
        CreateMap<Exercises, ExercisesDto>()
            .ForMember(e => e.Id, e => e.MapFrom(e => e.Id));
        CreateMap<CreateExercisesDto, Exercises>()
            .ForMember(e => e.Id, e => e.MapFrom(dto => new Exercises
            {
                Id = dto.Id
            }));
    }
    
}