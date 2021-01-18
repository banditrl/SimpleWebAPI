using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Domain.Interfaces;

namespace SimpleWebAPI.Api.Controllers
{
	[ApiController]
	[Route("api/WeatherForecast")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly IWeatherForecastService _weatherForecast;

		public WeatherForecastController(IWeatherForecastService weatherForecast)
		{
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
