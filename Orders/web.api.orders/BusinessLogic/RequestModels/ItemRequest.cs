namespace web.api.orders.BusinessLogic.RequestModels;

public class ItemRequest
{
    public required string Name { get; set; }

    public required decimal Price { get; set; }
}
