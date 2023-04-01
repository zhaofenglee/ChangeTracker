using JS.Abp.ChangeTracker.ChangeLogs;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace JS.Abp.ChangeTracker.MongoDB;

[ConnectionStringName(ChangeTrackerDbProperties.ConnectionStringName)]
public interface IChangeTrackerMongoDbContext : IAbpMongoDbContext
{
    IMongoCollection<ChangeLog> ChangeLogs { get; }
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}