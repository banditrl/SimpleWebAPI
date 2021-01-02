using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleInjector;
using SimpleWebAPI.Infrastructure.IoC;
using SimpleWebAPI.CrossCutting.Configuration;
using System.Globalization;
using SimpleWebAPI.Api.Infrastructure.Configuration;
using SimpleWebAPI.Api.Infrastructure.Middlewares;

namespace SimpleWebAPI.Api
{
	using Container = Container;

	public class Startup
	{
		public Container _container { get; }
		public IConfiguration _configuration { get; set; }

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;

			_container = new Container();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("AllowAllHeaders", builder =>
				{
					builder
						.AllowAnyHeader()
						.AllowAnyMethod()
						.AllowAnyOrigin();
				});
			});

			services.AddMvc();

			services.AddControllers();

			services.Configure<AppSettings>(_configuration);

			services.AddSwaggerGenOptions();

			services.AddSimpleInjector(_container, opt =>
			{
				opt.AddAspNetCore().AddControllerActivation();
			});

			Bootstrapper.Register(_container);
			CultureInfo.CurrentCulture = new CultureInfo("pt-BR");
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDeveloperExceptionPage();

			app.UseCors("AllowAllHeaders");

			app.UseAuthenticationMiddleware();

			app.UseSwaggerConfiguration();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSimpleInjector(_container);

			_container.Verify();
		}
	}
}
