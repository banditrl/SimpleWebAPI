using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleWebAPI.Presentation
{
	public class SwaggerConfiguration
	{
		public void ConfigureSwaggerServices(IServiceCollection services)
		{
			services.AddSwaggerGen();
		}

		public void ConfigureSwaggerApp(IApplicationBuilder app)
		{
			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
				c.RoutePrefix = string.Empty;
			});
		}
	}
}
