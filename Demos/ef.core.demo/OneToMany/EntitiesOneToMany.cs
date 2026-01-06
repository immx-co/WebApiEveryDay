namespace ef.core.demo.OneToMany;

public class CompanyOneToMany
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public List<UserOneToMany> Users { get; set; } = new();
}

public class UserOneToMany
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int CompanyId { get; set; }

    public CompanyOneToMany? Company { get; set; }
}
