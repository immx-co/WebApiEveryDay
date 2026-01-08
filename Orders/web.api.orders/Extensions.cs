using Microsoft.EntityFrameworkCore;
using web.api.orders.BusinessLogic;
using web.api.orders.Database;
using web.api.orders.Database.Items;
using web.api.orders.Database.OrderLines;
using web.api.orders.Database.Orders;

namespace web.api.orders;

public static class Extensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IItemRepository, ItemRepository>();
        serviceCollection.AddScoped<IOrderRepository, OrderRepository>();

        serviceCollection.AddDbContext<ApplicationContext>(x =>
        {
            x.UseNpgsql("Host=localhost;Port=5432;Database=OrdersDb6;Username=postgres;Password=topiho99");
        });

        return serviceCollection;
    }

    public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IItemService, ItemService>();
        serviceCollection.AddScoped<IOrderService, OrderService>();
        serviceCollection.AddScoped<IOrderLineRepository, OrderLineRepository>();

        return serviceCollection;
    }
}
