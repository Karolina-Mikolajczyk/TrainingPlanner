using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;

namespace WebApplication1.Controllers;

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
        
        return Ok ("Wszystkie zasoby zostały usunięte");
    }
    [HttpPost]
    public ActionResult CreateExercises([FromBody] CreateExercisesDto dto)
    {
        // var exercises = _mapper.Map<Exercises>(dto);
        var exercises = dto.ToExercise(); // extensions method w c#
        _dbContext.Exercises.Add(exercises);
        _dbContext.SaveChanges();
        
        return Created($"/api/exercises/{exercises.Id}", null);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Exercises>> GetAll()
    {
        // pobierz wszystrkie exercises w bazie danych
        var exercises = _dbContext
            .Exercises
            .ToList();
        return exercises;
    }
    
    // Exercises dodatkowy get do pobrania konkretnego exercies po przekazanym ID
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