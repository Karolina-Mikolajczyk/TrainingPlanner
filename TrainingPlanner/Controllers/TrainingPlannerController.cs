using Microsoft.AspNetCore.Mvc;
using TrainingPlanner.Contracts;
using TrainingPlanner.Entities;

namespace TrainingPlanner.Controllers;

[Route("api/exercises")]
public class TrainingPlannerController : ControllerBase
{
    private readonly TrainingPlannerDbContext _dbContext;

     public TrainingPlannerController(TrainingPlannerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpDelete("delete-all")]
    public IActionResult DeleteAllRecords()
    {
        var allRecords = _dbContext.Exercises.ToList();
        _dbContext.Exercises.RemoveRange(allRecords);
        _dbContext.SaveChanges();
        
        return Ok ();
    }
    [HttpPost]
    public ActionResult CreateExercises([FromBody] CreateExercisesDto dto)
    {
        var exercises = dto.ToExercise(); // extensions method w c#
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
        return exercises;
    }
    
    [HttpGet("{id}")]
    public ActionResult<Exercises> Get([FromRoute] int id)
    {
        var exercises = _dbContext
            .Exercises
            .FirstOrDefault(e => e.Id == id);
        if (exercises is null)
        {
            return NotFound();
        }

        return Ok(exercises);
    }
}