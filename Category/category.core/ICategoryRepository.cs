using category.core.Models;

namespace category.core;

public interface ICategoryRepository
{
    Task<Guid> CreateAsync(Category category, CancellationToken ct);

    Task<string> GetImagePathAsync(Guid categoryId, CancellationToken ct);
}
