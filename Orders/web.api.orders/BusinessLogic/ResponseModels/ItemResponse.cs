namespace web.api.orders.BusinessLogic.ResponseModels;

public class ItemResponse
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }

    public required decimal Price { get; set; }
}
