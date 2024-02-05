using Microsoft.AspNetCore.Mvc;
using TrainingPlanner.Domain;

namespace TrainingPlanner.Controllers;


public record GeneratePlanDto(Gender Gender, ExercisesLevel ExercisesLevel);

[Route("api/plans")]
public class PlanController : ControllerBase
{
    public IActionResult GeneratePlan([FromBody] GeneratePlanDto generatePlanDto)
    {
        throw new NotImplementedException();
    }
}