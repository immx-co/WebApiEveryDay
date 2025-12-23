namespace web.api.orders.Contracts;

public class ItemBase
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; }

    public decimal Price { get; set; }
}
