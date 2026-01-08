using Microsoft.EntityFrameworkCore;
using web.api.orders.Contracts;

namespace web.api.orders.Database.OrderLines;

public class OrderLineRepository(ApplicationContext dbContext) : IOrderLineRepository
{
    public async Task CreateAsync(OrderLine orderLine, CancellationToken ct)
    {
        await dbContext.OrderLines.AddAsync(orderLine);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<OrderLine>> GetByOrderId(Guid orderId, CancellationToken ct)
    {
        return await dbContext.OrderLines
            .Where(ol => ol.OrderId == orderId)
            .ToListAsync(ct);
    }
}
