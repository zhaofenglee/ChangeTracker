using JS.Abp.ChangeTracker.ChangeTypes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace JS.Abp.ChangeTracker.ChangeLogs
{
    public class ChangeLogCreateDto
    {
        public Guid? UserId { get; set; }
        [StringLength(ChangeLogConsts.UserNameMaxLength)]
        public string? UserName { get; set; }
        public string? Description { get; set; }
        public ChangeType ChangeType { get; set; } = ((ChangeType[])Enum.GetValues(typeof(ChangeType)))[0];
        public Guid SystemId { get; set; }
        [StringLength(ChangeLogConsts.SystemNameMaxLength)]
        public string? SystemName { get; set; }
    }
}