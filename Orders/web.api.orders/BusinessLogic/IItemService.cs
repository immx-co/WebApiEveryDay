using web.api.orders.BusinessLogic.RequestModels;
using web.api.orders.Contracts;

namespace web.api.orders.BusinessLogic;

public interface IItemService
{
    Task<Guid> CreateAsync(ItemRequest item, CancellationToken ct = default);

    Task<List<Item>> GetAllAsync(CancellationToken ct = default);
}
