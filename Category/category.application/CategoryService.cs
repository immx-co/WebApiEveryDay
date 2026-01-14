using category.application.Contracts.Request;
using category.core;
using category.core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using category.application.Contracts.Response;

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

        var categoryId = Guid.NewGuid();

        var extension = Path.GetExtension(categoryRequest.Image.FileName);
        var fileName = $"{categoryId}{extension}";
        var filePath = Path.Combine(uploadsDir, fileName);

        await using var stream = File.Create(filePath);
        await categoryRequest.Image.CopyToAsync(stream, ct);

        var category = new Category
        {
            Id = categoryId,
            Name = categoryRequest.Name,
            CreatedAt = DateTime.UtcNow,
            ImagePath = filePath,
            ImageUrl = $"/uploads/categories/{fileName}"
        };

        return await categoryRepository.CreateAsync(category, ct);
    }

    public async Task<ImageInfo> GetImagePathAsync(Guid categoryId, CancellationToken ct = default)
    {
        var imagePath = await categoryRepository.GetImagePathAsync(categoryId, ct);
        if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
            throw new ArgumentException("Не найдена картинка по переданному идентификатору категории.");

        var provider = new FileExtensionContentTypeProvider();
        if (!provider.TryGetContentType(imagePath, out var contentType))
            contentType = "application/octet-stream";

        return new ImageInfo(imagePath, contentType);
    }

    public async Task<List<CategoryInfo>> GetAllCategoryInfos(CancellationToken ct = default)
    {
        var allDbCategories = await categoryRepository.GetAllAsync(ct);
        return allDbCategories.Select(c => new CategoryInfo
        {
            Id = c.Id,
            Name = c.Name,
        }).ToList();
    }
}
