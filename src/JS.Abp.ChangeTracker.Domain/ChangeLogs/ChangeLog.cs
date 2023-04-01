using JS.Abp.ChangeTracker.ChangeTypes;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace JS.Abp.ChangeTracker.ChangeLogs
{
    public class ChangeLog : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid? UserId { get; set; }

        [CanBeNull]
        public virtual string? UserName { get; set; }

        [CanBeNull]
        public virtual string? Description { get; set; }

        public virtual ChangeType ChangeType { get; set; }

        public virtual Guid SystemId { get; set; }

        [CanBeNull]
        public virtual string? SystemName { get; set; }

        public ChangeLog()
        {

        }

        public ChangeLog(Guid id, string userName, string description, ChangeType changeType, Guid systemId, string systemName, Guid? userId = null)
        {

            Id = id;
            Check.Length(userName, nameof(userName), ChangeLogConsts.UserNameMaxLength, 0);
            Check.Length(systemName, nameof(systemName), ChangeLogConsts.SystemNameMaxLength, 0);
            UserName = userName;
            Description = description;
            ChangeType = changeType;
            SystemId = systemId;
            SystemName = systemName;
            UserId = userId;
        }

    }
}