using JS.Abp.ChangeTracker.ChangeTypes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace JS.Abp.ChangeTracker.ChangeLogs
{
    public class ChangeLogUpdateDto : IHasConcurrencyStamp
    {
        public Guid? UserId { get; set; }
        [StringLength(ChangeLogConsts.UserNameMaxLength)]
        public string? UserName { get; set; }
        public string? Description { get; set; }
        public ChangeType ChangeType { get; set; }
        public Guid SystemId { get; set; }
        [StringLength(ChangeLogConsts.SystemNameMaxLength)]
        public string? SystemName { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}