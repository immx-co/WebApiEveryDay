namespace web.api.orders.BusinessLogic.RequestModels;

public class OrderRequest
{
    public required string Name { get; init; }

    public required List<ItemInfo> ItemInfos { get; set; }
}

public class ItemInfo
{
    public required Guid ItemId { get; set; }

    public required int Quantity { get; set; } = 1;
}
