using category.core;

namespace category.application;

public class MonitoringService(ICategoryRepository categoryRepository) : IMonitoringService
{
    private int _step = 0;

    private readonly TimeSpan _timespan = TimeSpan.FromHours(1);

    public async Task MonitorExpiredCategories(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            var allCategoryEntities = await categoryRepository.GetAllAsync(ct);

            foreach(var category in allCategoryEntities)
            {
                var now = DateTime.UtcNow;
                if ((category.CreatedAt + _timespan) > now && (category.CreatedAt + _timespan) < (now + _timespan))
                    continue;
                await categoryRepository.DeleteByIdAsync(category.Id, ct);
            }

            _step++;
            Console.WriteLine($"Прочекано: {_step}...");

            await Task.Delay(TimeSpan.FromSeconds(5), ct);
        }
    }
}
