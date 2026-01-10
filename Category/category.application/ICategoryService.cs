using category.application.Contracts.Request;
using Microsoft.AspNetCore.Hosting;

namespace category.application;

public interface ICategoryService
{
    Task<Guid> CreateAsync(CreateCategory categoryRequest, IWebHostEnvironment env, CancellationToken ct = default);
}
