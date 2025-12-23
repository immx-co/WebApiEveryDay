using web.api.orders.Contracts;

namespace web.api.orders.Database;

public interface IOrderRepository
{
    Task<Guid> CreateAsync(Order order, CancellationToken ct);

    Task<Order> GetByIdAsync(Guid id, CancellationToken ct);
}
