using JS.Abp.ChangeTracker.ChangeLogs;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace JS.Abp.ChangeTracker.MongoDB;

[ConnectionStringName(ChangeTrackerDbProperties.ConnectionStringName)]
public class ChangeTrackerMongoDbContext : AbpMongoDbContext, IChangeTrackerMongoDbContext
{
    public IMongoCollection<ChangeLog> ChangeLogs => Collection<ChangeLog>();
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureChangeTracker();

        modelBuilder.Entity<ChangeLog>(b => { b.CollectionName = ChangeTrackerDbProperties.DbTablePrefix + "ChangeLogs"; });
    }
}