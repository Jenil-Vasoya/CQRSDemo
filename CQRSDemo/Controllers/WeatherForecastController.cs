using CQRSDemo.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly CIPlatformContext _CIPlatformContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, CIPlatformContext CIPlatformContext)
        {
            _logger = logger; 
            _CIPlatformContext = CIPlatformContext;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var user = _CIPlatformContext.Users.FirstOrDefault(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        
        
    }
}