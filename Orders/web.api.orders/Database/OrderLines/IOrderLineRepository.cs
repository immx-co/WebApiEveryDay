using web.api.orders.Contracts;

namespace web.api.orders.Database.OrderLines;

public interface IOrderLineRepository
{
    Task CreateAsync(OrderLine orderLine, CancellationToken ct);

    Task<List<OrderLine>> GetByOrderId(Guid orderId, CancellationToken ct);
}
