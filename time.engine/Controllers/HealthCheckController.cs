using Microsoft.AspNetCore.Mvc;
using time.engine.contracts;

namespace time.engine.api.Controllers
{
    [ApiController]
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly ITimeService _timeService;

        public HealthCheckController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_timeService.CurrentDateTime());
        }
    }
}
