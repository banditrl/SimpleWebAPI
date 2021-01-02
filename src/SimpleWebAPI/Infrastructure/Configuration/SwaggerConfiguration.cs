using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SimpleWebAPI.Api.Infrastructure.Filters;

namespace SimpleWebAPI.Api.Infrastructure.Configuration
{
	public static class SwaggerConfiguration
	{
		public static void UseSwaggerConfiguration(this IApplicationBuilder app)
		{
			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

				c.RoutePrefix = string.Empty;
			});
		}

		public static void AddSwaggerGenOptions(this IServiceCollection services)
		{
			var swaggerHeaderFilters = new SwaggerHeaderFilters();

			services.AddSwaggerGen(c =>
			{
				c.OperationFilter<SwaggerHeaderFilters>();

				c.AddSecurityDefinition("Bearer", swaggerHeaderFilters.SecurityScheme);

				c.AddSecurityRequirement(swaggerHeaderFilters.SecurityRequirement);
			});
		}
	}
}
