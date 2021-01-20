using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebAPI.Infrastructure.Data.Interfaces
{
    public interface IWeatherForecastRepository
    {
        public void InsertForecastWeek(DateTime date, int temperatureC, int temperatureF, string summary);
    }
}
