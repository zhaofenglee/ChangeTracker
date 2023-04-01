using JS.Abp.ChangeTracker.ChangeTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using JS.Abp.ChangeTracker.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using MongoDB.Driver.Linq;
using MongoDB.Driver;

namespace JS.Abp.ChangeTracker.ChangeLogs
{
    public class MongoChangeLogRepository : MongoDbRepository<ChangeTrackerMongoDbContext, ChangeLog, Guid>, IChangeLogRepository
    {
        public MongoChangeLogRepository(IMongoDbContextProvider<ChangeTrackerMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<ChangeLog>> GetListAsync(
            string filterText = null,
            Guid? userId = null,
            string userName = null,
            string description = null,
            ChangeType? changeType = null,
            Guid? systemId = null,
            string systemName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, userId, userName, description, changeType, systemId, systemName);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ChangeLogConsts.GetDefaultSorting(false) : sorting);
            return await query.As<IMongoQueryable<ChangeLog>>()
                .PageBy<ChangeLog, IMongoQueryable<ChangeLog>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(
           string filterText = null,
           Guid? userId = null,
           string userName = null,
           string description = null,
           ChangeType? changeType = null,
           Guid? systemId = null,
           string systemName = null,
           CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, userId, userName, description, changeType, systemId, systemName);
            return await query.As<IMongoQueryable<ChangeLog>>().LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ChangeLog> ApplyFilter(
            IQueryable<ChangeLog> query,
            string filterText,
            Guid? userId = null,
            string userName = null,
            string description = null,
            ChangeType? changeType = null,
            Guid? systemId = null,
            string systemName = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.UserName.Contains(filterText) || e.Description.Contains(filterText) || e.SystemName.Contains(filterText))
                    .WhereIf(userId.HasValue, e => e.UserId == userId)
                    .WhereIf(!string.IsNullOrWhiteSpace(userName), e => e.UserName.Contains(userName))
                    .WhereIf(!string.IsNullOrWhiteSpace(description), e => e.Description.Contains(description))
                    .WhereIf(changeType.HasValue, e => e.ChangeType == changeType)
                    .WhereIf(systemId.HasValue, e => e.SystemId == systemId)
                    .WhereIf(!string.IsNullOrWhiteSpace(systemName), e => e.SystemName.Contains(systemName));
        }
    }
}