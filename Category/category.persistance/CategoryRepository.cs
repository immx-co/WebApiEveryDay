using category.core;
using category.core.Models;

namespace category.persistance;

public class CategoryRepository(ApplicationContext dbContext) : ICategoryRepository
{
    public async Task<Guid> CreateAsync(Category category, CancellationToken ct)
    {
        dbContext.Categories.Add(category);
        await dbContext.SaveChangesAsync(ct);
        return category.Id;
    }
}
