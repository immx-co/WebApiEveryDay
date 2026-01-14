namespace category.application.Contracts.Response;

public readonly record struct CategoryInfo
{
    public Guid Id { get; init; }

    public string Name { get; init; }
}
