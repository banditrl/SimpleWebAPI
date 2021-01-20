using System.Collections.Generic;
using SimpleWebAPI.Domain.Models;

namespace SimpleWebAPI.Domain.Interfaces
{
	public interface IWeatherForecastService
	{
		public IEnumerable<WeatherForecastModel> GetWeekPrevision();

		public IEnumerable<WeatherForecastModel> GetMonthPrevision();

	}
}
