using JS.Abp.ChangeTracker.ChangeTypes;
using Volo.Abp.Application.Dtos;
using System;

namespace JS.Abp.ChangeTracker.ChangeLogs
{
    public class ChangeLogExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Description { get; set; }
        public ChangeType? ChangeType { get; set; }
        public Guid? SystemId { get; set; }
        public string? SystemName { get; set; }

        public ChangeLogExcelDownloadDto()
        {

        }
    }
}