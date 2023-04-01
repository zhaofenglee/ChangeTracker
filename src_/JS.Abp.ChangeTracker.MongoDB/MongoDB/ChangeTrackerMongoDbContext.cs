using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace JS.Abp.ChangeTracker.MongoDB;

[ConnectionStringName(ChangeTrackerDbProperties.ConnectionStringName)]
public class ChangeTrackerMongoDbContext : AbpMongoDbContext, IChangeTrackerMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureChangeTracker();
    }
}
