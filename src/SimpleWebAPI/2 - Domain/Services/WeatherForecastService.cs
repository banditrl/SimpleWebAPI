using System;
using System.Collections.Generic;
using System.Linq;
using SimpleWebAPI.Domain.Interfaces;
using SimpleWebAPI.Domain.Models;

namespace SimpleWebAPI.Domain.Services
{
	public class WeatherForecastService : IWeatherForecastService
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		public IEnumerable<WeatherForecastModel> GetWeekPrevision()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecastModel
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
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
