using Microsoft.OpenApi.Models;

namespace RedditClone.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Reddit Clone API",
                    Version = "v1"
                });
            });

            // Add Problem Details support for consistent error responses
            services.AddProblemDetails();

            return services;
        }

        public static WebApplication UsePresentation(this WebApplication app)
        {
            // Use built-in exception handler for unhandled exceptions
            app.UseExceptionHandler();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reddit Clone API v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}