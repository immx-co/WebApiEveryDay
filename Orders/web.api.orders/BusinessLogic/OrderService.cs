using web.api.orders.BusinessLogic.RequestModels;
using web.api.orders.Contracts;
using web.api.orders.Database;

namespace web.api.orders.BusinessLogic;

public class OrderService(
    IOrderRepository orderRepository, 
    IItemRepository itemRepository) : IOrderService
{
    public async Task<Guid> CreateAsync(OrderRequest orderRequest, CancellationToken ct = default)
    {
        var items = new List<Item>();

        foreach (var itemId in orderRequest.ItemIds)
        {
            if (await itemRepository.CheckItem(itemId, ct) == false)
                throw new ArgumentException($"Товар с Id == {itemId} не найден.");

            var item = await itemRepository.GetByIdAsync(itemId, ct);
            items.Add(item);
        }

        var order = new Order
        {
            Name = orderRequest.Name,
            ItemIds = items.Select(i => i.Id).ToList(),
            Price = items.Sum(i => i.Price),
            Created = DateTime.UtcNow,
        };

        return await orderRepository.CreateAsync(order, ct);
    } 

    public async Task<Order> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var order = await orderRepository.GetByIdAsync(id, ct);

        if (order is null)
            throw new NullReferenceException($"Заказ с Id == {id} не найден.");

        return order;
    }
}
