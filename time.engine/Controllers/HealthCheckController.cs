using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using time.engine.api.Configuration;
using time.engine.contracts;

namespace time.engine.api.Controllers
{
    [ApiController]
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly ITimeService _timeService;
        private readonly IOptions<VersionConfig> _config;

        public HealthCheckController(IOptions<VersionConfig> config, ITimeService timeService)
        {
            _timeService = timeService;
            _config = config;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { version = _config.Value.Version, date = _timeService.CurrentDateTime() });
        }
    }
}
