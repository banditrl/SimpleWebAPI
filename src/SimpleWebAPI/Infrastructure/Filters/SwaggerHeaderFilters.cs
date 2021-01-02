using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace SimpleWebAPI.Api.Infrastructure.Filters
{
    public class SwaggerHeaderFilters : IOperationFilter
    {
        public OpenApiSecurityScheme SecurityScheme { get; } = new OpenApiSecurityScheme()
        {
            Description = "JWT Authorization header using the Bearer scheme.",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "bearer"
        };

        public OpenApiSecurityRequirement SecurityRequirement { get; } = new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                }, new List<string>()
            }
        };

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var stringSchema = new OpenApiSchema() { Type = "string" };

            operation.Parameters = operation.Parameters ?? new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Culture",
                Example = new OpenApiString("pt-BR"),
                In = ParameterLocation.Header,
                Schema = stringSchema,
                Required = false
            });
        }
    }
}
