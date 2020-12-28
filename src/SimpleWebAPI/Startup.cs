using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleInjector;
using SimpleWebAPI.Infrastructure.IoC;
using SimpleWebAPI.CrossCutting.Configuration;

namespace SimpleWebAPI
{
	using Container = Container;

	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;

			_container = new Container();
		}

		public Container _container { get; }
		public IConfiguration _configuration { get; set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddSwaggerGen();

			services.AddMvc();

			services.Configure<AppSettings>(_configuration.GetSection("AppSettings"));

			services.AddSimpleInjector(_container, opt =>
			{
				opt.AddAspNetCore().AddControllerActivation();
			});

			Bootstrapper.Register(_container);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			//var builder = new ConfigurationBuilder()
			//.SetBasePath(env.ContentRootPath)
			//.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

			//_configuration = builder.Build();

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

				c.RoutePrefix = string.Empty;
			});

			app.UseSimpleInjector(_container);

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

			_container.Verify();
		}
	}
}
