using category.core;
using category.core.Models;
using Microsoft.EntityFrameworkCore;

namespace category.persistance;

public class CategoryRepository(ApplicationContext dbContext) : ICategoryRepository
{
    public async Task<Guid> CreateAsync(Category category, CancellationToken ct)
    {
        await dbContext.Categories.AddAsync(category, ct);
        await dbContext.SaveChangesAsync(ct);
        return category.Id;
    }

    public async Task<string?> GetImagePathAsync(Guid categoryId, CancellationToken ct)
    {
        var category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId, ct);
        if (category is not null)
            return category.ImagePath;
        return null;
    }
}
