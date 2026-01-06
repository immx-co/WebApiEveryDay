using web.api.orders.BusinessLogic.RequestModels;
using web.api.orders.Contracts;
using web.api.orders.Database.Items;

namespace web.api.orders.BusinessLogic;

public class ItemService(IItemRepository itemRepository) : IItemService
{
    public async Task<Guid> CreateAsync(ItemRequest item, CancellationToken ct = default)
    {
        var createdItem = new Item
        {
            Name = item.Name,
            Price = item.Price,
        };

        return await itemRepository.CreateAsync(createdItem, ct);
    }

    public async Task<List<Item>> GetAllAsync(CancellationToken ct = default)
    {
        return await itemRepository.GetAllAsync(ct);
    }
}
