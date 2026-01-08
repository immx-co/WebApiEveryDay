namespace web.api.orders.Contracts;

public class OrderLine
{
    public required Guid OrderId { get; set; }

    public required Guid ItemId { get; set; }

    public required int Quantity { get; set; }
}
