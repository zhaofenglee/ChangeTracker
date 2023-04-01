using JS.Abp.ChangeTracker.ChangeTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using JS.Abp.ChangeTracker.EntityFrameworkCore;

namespace JS.Abp.ChangeTracker.ChangeLogs
{
    public class EfCoreChangeLogRepository : EfCoreRepository<ChangeTrackerDbContext, ChangeLog, Guid>, IChangeLogRepository
    {
        public EfCoreChangeLogRepository(IDbContextProvider<ChangeTrackerDbContext> dbContextProvider)
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, userId, userName, description, changeType, systemId, systemName);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ChangeLogConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, userId, userName, description, changeType, systemId, systemName);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
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