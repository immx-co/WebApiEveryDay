using category.application.Contracts.Request;
using category.core;
using category.core.Models;
using Microsoft.AspNetCore.Hosting;

namespace category.application;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<Guid> CreateAsync(CreateCategory categoryRequest, IWebHostEnvironment env, CancellationToken ct = default)
    {
        if(categoryRequest.Image is null || categoryRequest.Image.Length <= 0)
            throw new ArgumentException("Не передано изображение для категории.");

        if (!categoryRequest.Image.ContentType.StartsWith("image/"))
            throw new ArgumentException("Передано не изображение.");

        var uploadsDir = Path.Combine(env.WebRootPath, "uploads", "categories");
        Directory.CreateDirectory(uploadsDir);

        var extension = Path.GetExtension(categoryRequest.Image.FileName);
        var fileName = $"{Guid.NewGuid():N}{extension}";
        var filePath = Path.Combine(uploadsDir, fileName);

        await using var stream = System.IO.File.Create(filePath);
        await categoryRequest.Image.CopyToAsync(stream, ct);

        var category = new Category
        {
            Name = categoryRequest.Name,
            CreatedAt = DateTime.UtcNow,
            ImagePath = filePath,
            ImageUrl = $"/uploads/categories/{fileName}"
        };

        return await categoryRepository.CreateAsync(category, ct);
    }
}
