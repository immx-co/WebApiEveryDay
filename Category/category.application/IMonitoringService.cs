namespace category.application;

public interface IMonitoringService
{
    Task MonitorExpiredCategories(CancellationToken ct);
}
