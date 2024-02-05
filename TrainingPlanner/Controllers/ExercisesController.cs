using Microsoft.AspNetCore.Mvc;
using TrainingPlanner.Contracts;
using TrainingPlanner.Entities;

namespace TrainingPlanner.Controllers;

[Route("api/exercises")]
public class ExercisesController : ControllerBase
{
    private readonly TrainingPlannerDbContext _dbContext;

     public ExercisesController(TrainingPlannerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpDelete("delete-all")]
    public IActionResult DeleteAllRecords()
    {
        var allRecords = _dbContext.Exercises.ToList();
        _dbContext.Exercises.RemoveRange(allRecords);
        _dbContext.SaveChanges();
        
        return Ok();
    }

    [HttpDelete("{id:long}")]
    public IActionResult DeleteExercise([FromRoute] long id)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost]
    public ActionResult CreateExercises([FromBody] CreateExerciseDto dto)
    {
        var exercises = dto.ToExercise(); // extensions method w c#
        _dbContext.Exercises.Add(exercises);
        _dbContext.SaveChanges();
        
        return Created($"/api/exercises/{exercises.Id}", null);
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile([FromBody] IFormFile file)
    {
        throw new NotImplementedException();
    }
    
    
    [HttpGet]
    public ActionResult<IEnumerable<Exercise>> GetAll()
    {
        var exercises = _dbContext
            .Exercises
            .ToList();
        return exercises;
    }
    
    [HttpGet("{id:long}")]
    public ActionResult<Exercise> Get([FromRoute] long id)
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