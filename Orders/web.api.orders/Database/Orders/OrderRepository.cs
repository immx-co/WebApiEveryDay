using Microsoft.EntityFrameworkCore;
using web.api.orders.Contracts;

namespace web.api.orders.Database.Orders;

public class OrderRepository(ApplicationContext dbContext) : IOrderRepository
{
    public async Task<Guid> CreateAsync(Order order, CancellationToken ct)
    {
        await dbContext.Orders.AddAsync(order, ct);
        await dbContext.SaveChangesAsync(ct);
        return order.Id;
    }

    public async Task<Order> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var order = await dbContext.Orders
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
            throw new NullReferenceException($"Заказа с Id == {id} не существует.");

        return order;
    }
}
