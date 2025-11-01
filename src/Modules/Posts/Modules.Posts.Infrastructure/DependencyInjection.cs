using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Posts.Application;
using Modules.Posts.Application.Common.Contracts;
using Modules.Posts.Infrastructure.Persistence;


namespace Modules.Posts.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPostModule(this IServiceCollection services,ConfigurationManager configuration)
        {
 

            services.AddPostApplication(configuration);
            services.AddPostInfrastructure(configuration);


            return services;
        }

        private static IServiceCollection AddPostInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {   // Register DbContext
            services.AddDbContext<PostsDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            services.AddScoped<IPostsDbContext>(provider => provider.GetRequiredService<PostsDbContext>());
            return services;
        }
        private static IServiceCollection AddPostApplication(this IServiceCollection services, ConfigurationManager configuration)
        {   // Register Application layer
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(typeof(PostsApplicationMarker).Assembly);

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(PostsApplicationMarker).Assembly);
                // cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
                //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });

            return services;
        }
    }
}
