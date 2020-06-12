using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PocSwagger.ViewModel;
using System;
using System.Linq;

namespace PocSwagger.Controllers
{
    /// <summary>
    /// Previsão do tempo
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    [Produces("application/json")]
    [Route("api/v1/previsao-tempo")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Congelamento", "Órtese", "Frio", "Frio", "Suave", "Quente", "Agradável", "Quente", "Sufocante", "Escaldante"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary></summary>
        /// <param name="logger"></param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Busca os valores aleatórios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var rng = new Random();
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
            return Ok(result);
        }
    }
}
