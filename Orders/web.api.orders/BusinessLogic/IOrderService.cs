using web.api.orders.BusinessLogic.RequestModels;
using web.api.orders.Contracts;

namespace web.api.orders.BusinessLogic;

public interface IOrderService
{
    Task<Guid> CreateAsync(OrderRequest orderRequest, CancellationToken ct = default);

    Task<Order> GetByIdAsync(Guid id, CancellationToken ct = default);
}
