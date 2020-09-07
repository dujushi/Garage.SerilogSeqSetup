using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Garage.SerilogSeqSetup.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly ILogger<LogsController> _logger;

        public LogsController(ILogger<LogsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public void Get()
        {
            _logger.LogInformation("{Name} {@Position} at {Time}", "Lemon", new { Longitude = 11, Latitude = 12 }, DateTime.UtcNow);
            var exception = new Exception("Engine error");
            exception.Data["ErrorNo"] = 1;
            _logger.LogError(exception, "Car crashed {Name}", "Apple");
        }
    }
}
