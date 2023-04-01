using JS.Abp.ChangeTracker.ChangeTypes;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace JS.Abp.ChangeTracker.ChangeLogs
{
    public interface IChangeLogRepository : IRepository<ChangeLog, Guid>
    {
        Task<List<ChangeLog>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            Guid? userId = null,
            string userName = null,
            string description = null,
            ChangeType? changeType = null,
            Guid? systemId = null,
            string systemName = null,
            CancellationToken cancellationToken = default);
    }
}