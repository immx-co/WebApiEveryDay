using category.application.Contracts.Request;
using category.application.Contracts.Response;
using Microsoft.AspNetCore.Hosting;
using System.Runtime.CompilerServices;

namespace category.application;

public interface ICategoryService
{
    Task<Guid> CreateAsync(CreateCategory categoryRequest, IWebHostEnvironment env, CancellationToken ct = default);

    Task<ImageInfo> GetImagePathAsync(Guid categoryId, CancellationToken ct = default);

    Task<List<CategoryInfo>> GetAllCategoryInfos(CancellationToken ct = default);
}
