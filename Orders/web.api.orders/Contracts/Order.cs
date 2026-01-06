namespace web.api.orders.Contracts;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; }

    public decimal Price { get; set; }

    public DateTime Created { get; set; }

    public List<Item> Items { get; set; } = new();
}
