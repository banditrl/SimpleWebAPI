using System;
using System.Collections.Generic;
using System.Linq;
using SimpleWebAPI.Domain.Interfaces;
using SimpleWebAPI.Domain.Models;
using SimpleWebAPI.Infrastructure.Data.Interfaces;

namespace SimpleWebAPI.Domain.Services
{
	public class WeatherForecastService : IWeatherForecastService
	{
		private readonly IWeatherForecastRepository _weatherForecast;

		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		public WeatherForecastService(IWeatherForecastRepository weatherForecast)
        {
			_weatherForecast = weatherForecast;
        }
		public IEnumerable<WeatherForecastModel> GetWeekPrevision()
		{
			var rng = new Random();
			_weatherForecast.InsertForecastWeek();
			 var retorno = Enumerable.Range(1, 5).Select(index => new WeatherForecastModel
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
			return retorno;
		}

		public IEnumerable<WeatherForecastModel> GetMonthPrevision()
		{
			var rng = new Random();
			return Enumerable.Range(1, 30).Select(index => new WeatherForecastModel
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
