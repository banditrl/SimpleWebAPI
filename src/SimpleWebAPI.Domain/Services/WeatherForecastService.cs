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
            var x = new WeatherForecastModel();

            var rng = new Random();

            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecastModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
           .ToArray();

            foreach (var item in result)
            {
                _weatherForecast.InsertForecastWeek(item.Date, item.TemperatureC, item.TemperatureF, item.Summary);
            }

            return result;
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
