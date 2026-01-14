using category.application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace category.infrastructure;

public class BackgroundMonitoringService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public BackgroundMonitoringService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    /// <inheritdoc />
    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        using var scope = _scopeFactory.CreateScope();
        var monitoringService = scope.ServiceProvider.GetRequiredService<IMonitoringService>();

        await monitoringService.MonitorExpiredCategories(ct);
    }
}
