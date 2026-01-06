namespace ef.core.demo.ForegnKey;

public class UserForeignKey
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public CompanyForeignKey? Company { get; set; }
}

public class CompanyForeignKey
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public List<UserForeignKey> Users { get; set; } = new();
}
