using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using JS.Abp.ChangeTracker.Permissions;
using JS.Abp.ChangeTracker.ChangeLogs;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using JS.Abp.ChangeTracker.Shared;

namespace JS.Abp.ChangeTracker.ChangeLogs
{

    [Authorize(ChangeTrackerPermissions.ChangeLogs.Default)]
    public class ChangeLogsAppService : ApplicationService, IChangeLogsAppService
    {
        private readonly IDistributedCache<ChangeLogExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IChangeLogRepository _changeLogRepository;
        private readonly ChangeLogManager _changeLogManager;

        public ChangeLogsAppService(IChangeLogRepository changeLogRepository, ChangeLogManager changeLogManager, IDistributedCache<ChangeLogExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _changeLogRepository = changeLogRepository;
            _changeLogManager = changeLogManager;
        }
        public virtual async Task<PagedResultDto<ChangeLogDto>> GetListAsync(GetChangeLogsInput input)
        {
            var totalCount = await _changeLogRepository.GetCountAsync(input.FilterText, input.UserId, input.UserName, input.Description, input.ChangeType, input.SystemId, input.SystemName);
            var items = await _changeLogRepository.GetListAsync(input.FilterText, input.UserId, input.UserName, input.Description, input.ChangeType, input.SystemId, input.SystemName, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ChangeLogDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ChangeLog>, List<ChangeLogDto>>(items)
            };
        }

        public virtual async Task<ChangeLogDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ChangeLog, ChangeLogDto>(await _changeLogRepository.GetAsync(id));
        }

        [Authorize(ChangeTrackerPermissions.ChangeLogs.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _changeLogRepository.DeleteAsync(id);
        }

        [Authorize(ChangeTrackerPermissions.ChangeLogs.Create)]
        public virtual async Task<ChangeLogDto> CreateAsync(ChangeLogCreateDto input)
        {

            var changeLog = await _changeLogManager.CreateAsync(
            input.UserName, input.Description, input.ChangeType, input.SystemId, input.SystemName, input.UserId
            );

            return ObjectMapper.Map<ChangeLog, ChangeLogDto>(changeLog);
        }

        [Authorize(ChangeTrackerPermissions.ChangeLogs.Edit)]
        public virtual async Task<ChangeLogDto> UpdateAsync(Guid id, ChangeLogUpdateDto input)
        {

            var changeLog = await _changeLogManager.UpdateAsync(
            id,
            input.UserName, input.Description, input.ChangeType, input.SystemId, input.SystemName, input.UserId, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<ChangeLog, ChangeLogDto>(changeLog);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ChangeLogExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _changeLogRepository.GetListAsync(input.FilterText, input.UserId, input.UserName, input.Description, input.ChangeType, input.SystemId, input.SystemName);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ChangeLog>, List<ChangeLogExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ChangeLogs.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ChangeLogExcelDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}