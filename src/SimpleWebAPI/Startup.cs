using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleInjector;
using SimpleWebAPI.Infrastructure.IoC;

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

		public Container _container;
		public IConfiguration _configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddSwaggerGen();

			services.AddMvc();

			services.AddSimpleInjector(_container, opt =>
			{
				opt.AddAspNetCore().AddControllerActivation();
			});

			Bootstrapper.Register(_container);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
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
