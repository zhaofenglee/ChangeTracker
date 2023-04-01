using JS.Abp.ChangeTracker.ChangeTypes;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace JS.Abp.ChangeTracker.ChangeLogs
{
    public class ChangeLogDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Description { get; set; }
        public ChangeType ChangeType { get; set; }
        public Guid SystemId { get; set; }
        public string? SystemName { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}