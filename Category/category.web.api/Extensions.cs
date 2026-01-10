using category.application;
using category.core;
using category.persistance;
using Microsoft.EntityFrameworkCore;

namespace category.web.api;

public static class Extensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();

        serviceCollection.AddDbContext<ApplicationContext>(x =>
        {
            x.UseNpgsql("Host=localhost;Port=5432;Database=Category;Username=postgres;Password=topiho99");
        });

        return serviceCollection;
    }

    public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICategoryService, CategoryService>();
        return serviceCollection;
    }
}
