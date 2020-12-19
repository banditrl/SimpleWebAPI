using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleWebAPI.Domain.Interfaces;

namespace SimpleWebAPI.Controllers
{
	[ApiController]
	[Route("api/WeatherForecast")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> _logger;

		private readonly IWeatherForecastService _weatherForecast;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecast)
		{
			_logger = logger;

			_weatherForecast = weatherForecast;
		}

		[HttpGet]
		[Route("Week")]
		public IActionResult GetWeekPrevision()
		{
			var response = _weatherForecast.GetWeekPrevision();

			return Ok(response);
		}

		[HttpGet]
		[Route("Month")]
		public IActionResult GetMonthPrevision()
		{
			var response = _weatherForecast.GetMonthPrevision();

			return Ok(response);
		}
	}
}
