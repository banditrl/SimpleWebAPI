using AutoMapper;
using SimpleInjector;
using SimpleWebAPI.Domain.Interfaces;
using SimpleWebAPI.Domain.Profiles.Request;
using SimpleWebAPI.Domain.Services;

namespace SimpleWebAPI.Infrastructure.IoC
{
    using Container = Container;

    public static class Bootstrapper
    {
        public static void Register(Container container)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AuthModelRequestProfile>();
                cfg.AddProfile<AuthModelResponseProfile>();
            });

            var mapper = config.CreateMapper();
            container.RegisterInstance(mapper);

            container.Register<IAuthService, AuthService>(Lifestyle.Singleton);

            container.Register<IUserService, UserService>(Lifestyle.Singleton);

            container.Register<IWeatherForecastService, WeatherForecastService>(Lifestyle.Singleton);
        }
    }
}