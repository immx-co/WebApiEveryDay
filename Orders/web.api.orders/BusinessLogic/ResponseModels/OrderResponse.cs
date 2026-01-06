namespace web.api.orders.BusinessLogic.ResponseModels;

public class OrderResponse
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }

    public required decimal Price { get; set; }

    public required DateTime Created { get; set; }

    public required List<ItemResponse> Items { get; set; } = new();
}
