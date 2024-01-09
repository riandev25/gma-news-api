namespace gma_news_api.Infrastructure;

using System;
using gma_news_api.Application.Authors;
using gma_news_api.Application.Movies;
using gma_news_api.Application.News;
using gma_news_api.Application.Reviews;
using gma_news_api.Infrastructure.Databases.MoviesReviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");
        //Console.WriteLine(connectionString);

        // If the environment variable is not set, fallback to the configuration
        //if (string.IsNullOrEmpty(connectionString))
        //{
        //    connectionString = configuration.GetConnectionString("PostgreSqlServer");
        //}
        var connectionString = configuration.GetConnectionString("PostgreSqlServer");
        _ = services.AddDbContext<MovieReviewsDbContext>(options => options.UseNpgsql(connectionString), ServiceLifetime.Singleton);

        _ = services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        _ = services.AddSingleton<EntityFrameworkMovieReviewsRepository>();

        _ = services.AddSingleton<INewsRepository>(p => p.GetRequiredService<EntityFrameworkMovieReviewsRepository>());
        _ = services.AddSingleton<IAuthorsRepository>(p => p.GetRequiredService<EntityFrameworkMovieReviewsRepository>());
        _ = services.AddSingleton<IMoviesRepository>(x => x.GetRequiredService<EntityFrameworkMovieReviewsRepository>());
        _ = services.AddSingleton<IReviewsRepository>(x => x.GetRequiredService<EntityFrameworkMovieReviewsRepository>());

        _ = services.AddSingleton(TimeProvider.System);

        return services;
    }
}
