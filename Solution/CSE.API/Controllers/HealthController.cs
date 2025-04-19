using Microsoft.AspNetCore.Mvc;

namespace CSE.API.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    private readonly ILogger<HealthController> _logger;

    public HealthController(ILogger<HealthController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<HealthResponse> Get()
    {
        _logger.LogInformation("Getting health status");

        return new HealthResponse
        {
            Running = true,
            Date = DateOnly.FromDateTime(DateTime.UtcNow),
            Message = "Service operating successfully."
        };
    }
}
