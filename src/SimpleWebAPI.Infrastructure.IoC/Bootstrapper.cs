using SimpleInjector;
using SimpleWebAPI.Domain.Interfaces;
using SimpleWebAPI.Domain.Services;

namespace SimpleWebAPI.Infrastructure.IoC
{
    using Container = Container;

    public static class Bootstrapper
    {
        public static void Register(Container container)
        {
            container.Register<IWeatherForecastService, WeatherForecastService>(Lifestyle.Singleton);

            container.Register<IUserService, UserService>(Lifestyle.Singleton);
        }
    }
}