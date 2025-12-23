namespace web.api.orders.Contracts;

public class OrderBase
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; }

    public decimal Price { get; set; }

    public DateTime Created { get; set; }

    public ICollection<Guid> ItemIds { get; set; } = new List<Guid>();
}
