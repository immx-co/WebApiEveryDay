using web.api.orders.BusinessLogic.RequestModels;
using web.api.orders.BusinessLogic.ResponseModels;

namespace web.api.orders.BusinessLogic;

public interface IItemService
{
    Task<Guid> CreateAsync(ItemRequest item, CancellationToken ct = default);

    Task<List<ItemResponse>> GetAllAsync(CancellationToken ct = default);
}
