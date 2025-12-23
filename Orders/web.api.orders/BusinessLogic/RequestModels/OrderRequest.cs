namespace web.api.orders.BusinessLogic.RequestModels;

public class OrderRequest
{
    public required string Name { get; init; }

    public required List<Guid> ItemIds { get; init; }
}
