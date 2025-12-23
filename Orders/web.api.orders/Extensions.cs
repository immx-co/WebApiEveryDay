using Microsoft.EntityFrameworkCore;
using web.api.orders.BusinessLogic;
using web.api.orders.Database;

namespace web.api.orders;

public static class Extensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IItemRepository, ItemRepository>();
        serviceCollection.AddScoped<IOrderRepository, OrderRepository>();

        serviceCollection.AddDbContext<ApplicationContext>(x =>
        {
            x.UseNpgsql("Host=localhost;Port=5432;Database=OrdersDb4;Username=postgres;Password=topiho99");
        });

        return serviceCollection;
    }

    public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IItemService, ItemService>();
        serviceCollection.AddScoped<IOrderService, OrderService>();

        return serviceCollection;
    }
}
