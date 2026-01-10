using category.core.Models;

namespace category.core;

public interface ICategoryRepository
{
    Task<Guid> CreateAsync(Category category, CancellationToken ct);
}
