using FactoryWithDI.Math;
using Microsoft.AspNetCore.Mvc;

namespace FactoryWithDI.Controllers;

[ApiController]
[Route("[controller]")]
public class MathController : ControllerBase
{
    private readonly IMathOperationFactory _mathOperationFactory;

    public MathController(IMathOperationFactory mathOperationFactory)
    {
        _mathOperationFactory = mathOperationFactory;
    }

    [HttpGet("calculate")]
    public ActionResult Get(int a, int b, MathOperationType operationType)
    {
        var mathOperation = _mathOperationFactory.Create(operationType);
        var result = mathOperation.Calculate(a, b);
        return Ok(result);
    }
}