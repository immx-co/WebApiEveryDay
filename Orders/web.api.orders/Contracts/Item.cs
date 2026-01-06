namespace web.api.orders.Contracts;

public class Item
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    public decimal Price { get; set; }

    public List<Order> Orders { get; set; } = new();
}
