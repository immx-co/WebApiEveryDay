using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using web.api.orders.Contracts;

namespace web.api.orders.Database;

public class ItemRepository(ApplicationContext dbContext) : IItemRepository
{
    public async Task<Guid> CreateAsync(Item item, CancellationToken ct)
    {
        await dbContext.Items.AddAsync(item, ct);
        await dbContext.SaveChangesAsync(ct);
        return item.Id;
    }

    public async Task<List<Item>> GetAllAsync(CancellationToken ct)
    {
        return await dbContext.Items.ToListAsync();
    }

    public async Task<bool> CheckItem(Guid itemId, CancellationToken ct)
    {
        var findedItem = await dbContext.Items.FirstOrDefaultAsync(i => i.Id == itemId, ct);

        if (findedItem != null)
            return true;
        else
            return false;
    }

    public async Task<Item> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var item = await dbContext.Items.FirstOrDefaultAsync(i => i.Id == id, ct);
        if (item is not null)
            return item;
        else
            throw new NullReferenceException($"Товар с Id == {id} не найден.");
    }
}
