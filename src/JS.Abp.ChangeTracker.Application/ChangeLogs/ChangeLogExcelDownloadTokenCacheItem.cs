using System;

namespace JS.Abp.ChangeTracker.ChangeLogs;

[Serializable]
public class ChangeLogExcelDownloadTokenCacheItem
{
    public string Token { get; set; }
}