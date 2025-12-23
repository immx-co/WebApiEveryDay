using web.api.orders.Contracts;

namespace web.api.orders.Database;

public interface IItemRepository
{
    Task<Guid> CreateAsync(Item item, CancellationToken ct);

    Task<List<Item>> GetAllAsync(CancellationToken ct);

    Task<bool> CheckItem(Guid itemId, CancellationToken ct);

    Task<Item> GetByIdAsync(Guid id, CancellationToken ct);
}
