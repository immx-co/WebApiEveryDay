using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using web.api.orders.BusinessLogic.RequestModels;
using web.api.orders.BusinessLogic.ResponseModels;
using web.api.orders.Contracts;
using web.api.orders.Database.Items;
using web.api.orders.Database.OrderLines;
using web.api.orders.Database.Orders;

namespace web.api.orders.BusinessLogic;

public class OrderService(
    IOrderRepository orderRepository, 
    IItemRepository itemRepository,
    IOrderLineRepository orderLineRepository) : IOrderService
{
    public async Task<Guid> CreateAsync(OrderRequest orderRequest, CancellationToken ct = default)
    {
        var items = new List<Item>();

        foreach(var itemInfo in orderRequest.ItemInfos
            .GroupBy(ii => ii.ItemId)
            .Select(ii => ii.First()))
        {
            if (!await itemRepository.CheckItem(itemInfo.ItemId, ct))
                throw new ArgumentException($"Товар с Id == {itemInfo.ItemId} не найден.");

            items.Add(await itemRepository.GetByIdAsync(itemInfo.ItemId, ct));
        }

        var order = new Order
        {
            Name = orderRequest.Name,
            Items = items,
            Price = items.Sum(i => i.Price),
            Created = DateTime.UtcNow,
        };

        var orderLines = items.Select(i => new OrderLine
        {
            OrderId = order.Id,
            ItemId = i.Id,
            Quantity = orderRequest.ItemInfos
                .Where(ii => ii.ItemId == i.Id)
                .First().Quantity,
        });

        foreach (var orderLine in orderLines)
            await orderLineRepository.CreateAsync(orderLine, ct);

        return await orderRepository.CreateAsync(order, ct);
    } 

    public async Task<OrderResponse> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var dbOrder = await orderRepository.GetByIdAsync(id, ct);

        if (dbOrder is null)
            throw new NullReferenceException($"Заказ с Id == {id} не найден.");

        var orderLines = await orderLineRepository.GetByOrderId(dbOrder.Id, ct);

        var items = new List<ItemResponse>();

        foreach (var ol in orderLines)
        {
            var item = await itemRepository.GetByIdAsync(ol.ItemId, ct);

            for(int i = 0; i < ol.Quantity; i++)
            {
                items.Add(new ItemResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                });
            }
        }

        var orderResponse = new OrderResponse
        {
            Id = dbOrder.Id,
            Name = dbOrder.Name,
            Price = items.Select(i => i.Price).Sum(),
            Created = dbOrder.Created,
            Items = items,
        };

        return orderResponse;
    }
}
