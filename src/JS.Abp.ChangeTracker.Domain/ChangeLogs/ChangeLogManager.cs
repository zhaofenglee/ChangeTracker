using JS.Abp.ChangeTracker.ChangeTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace JS.Abp.ChangeTracker.ChangeLogs
{
    public class ChangeLogManager : DomainService
    {
        private readonly IChangeLogRepository _changeLogRepository;

        public ChangeLogManager(IChangeLogRepository changeLogRepository)
        {
            _changeLogRepository = changeLogRepository;
        }

        public async Task<ChangeLog> CreateAsync(
        string userName, string description, ChangeType changeType, Guid systemId, string systemName, Guid? userId = null)
        {
            Check.Length(userName, nameof(userName), ChangeLogConsts.UserNameMaxLength);
            Check.NotNull(changeType, nameof(changeType));
            Check.Length(systemName, nameof(systemName), ChangeLogConsts.SystemNameMaxLength);

            var changeLog = new ChangeLog(
             GuidGenerator.Create(),
             userName, description, changeType, systemId, systemName, userId
             );

            return await _changeLogRepository.InsertAsync(changeLog);
        }

        public async Task<ChangeLog> UpdateAsync(
            Guid id,
            string userName, string description, ChangeType changeType, Guid systemId, string systemName, Guid? userId = null, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.Length(userName, nameof(userName), ChangeLogConsts.UserNameMaxLength);
            Check.NotNull(changeType, nameof(changeType));
            Check.Length(systemName, nameof(systemName), ChangeLogConsts.SystemNameMaxLength);

            var changeLog = await _changeLogRepository.GetAsync(id);

            changeLog.UserName = userName;
            changeLog.Description = description;
            changeLog.ChangeType = changeType;
            changeLog.SystemId = systemId;
            changeLog.SystemName = systemName;
            changeLog.UserId = userId;

            changeLog.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _changeLogRepository.UpdateAsync(changeLog);
        }

    }
}