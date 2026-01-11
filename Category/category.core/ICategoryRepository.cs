using category.core.Models;

namespace category.core;

public interface ICategoryRepository
{
    Task<Guid> CreateAsync(Category category, CancellationToken ct);

    Task<string?> GetImagePathAsync(Guid categoryId, CancellationToken ct);

    Task<List<Category>> GetAllAsync(CancellationToken ct);

    Task<Guid> DeleteByIdAsync(Guid categoryId, CancellationToken ct);
}
