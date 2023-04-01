using JS.Abp.ChangeTracker.ChangeTypes;
using System;

namespace JS.Abp.ChangeTracker.ChangeLogs
{
    public class ChangeLogExcelDto
    {
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Description { get; set; }
        public ChangeType ChangeType { get; set; }
        public Guid SystemId { get; set; }
        public string? SystemName { get; set; }
    }
}