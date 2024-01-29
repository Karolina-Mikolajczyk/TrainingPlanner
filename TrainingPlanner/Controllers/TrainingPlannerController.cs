using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;

namespace WebApplication1.Controllers;

[Route("api/exercises")]
public class TrainingPlannerController : ControllerBase
{
    private readonly TrainingPlannerDbContext _dbContext;
    private readonly IMapper _mapper;

     public TrainingPlannerController(TrainingPlannerDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult CreateExercises([FromBody] CreateExercisesDto dto)
    {
        var exercises = _mapper.Map<Exercises>(dto);
        _dbContext.Exercises.Add(exercises);
        _dbContext.SaveChanges();

        return Created($"/api/exercises/{exercises.Id}", null);


    }

    [HttpGet]
    public ActionResult<IEnumerable<Exercises>> GetAll()
    {
        var exercises = _dbContext
            .Exercises
            .ToList();
        var exercisesDtos = _mapper.Map<List<ExercisesDto>>(exercises);


        return Ok(exercisesDtos);
    }
}