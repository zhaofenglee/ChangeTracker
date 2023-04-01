using Volo.Abp;
using Volo.Abp.MongoDB;

namespace JS.Abp.ChangeTracker.MongoDB;

public static class ChangeTrackerMongoDbContextExtensions
{
    public static void ConfigureChangeTracker(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
