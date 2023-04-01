using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using JS.Abp.ChangeTracker.ChangeLogs;
using Volo.Abp.Content;
using JS.Abp.ChangeTracker.Shared;

namespace JS.Abp.ChangeTracker.ChangeLogs
{
    [RemoteService(Name = "ChangeTracker")]
    [Area("changeTracker")]
    [ControllerName("ChangeLog")]
    [Route("api/change-tracker/change-logs")]
    public class ChangeLogController : AbpController, IChangeLogsAppService
    {
        private readonly IChangeLogsAppService _changeLogsAppService;

        public ChangeLogController(IChangeLogsAppService changeLogsAppService)
        {
            _changeLogsAppService = changeLogsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ChangeLogDto>> GetListAsync(GetChangeLogsInput input)
        {
            return _changeLogsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ChangeLogDto> GetAsync(Guid id)
        {
            return _changeLogsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ChangeLogDto> CreateAsync(ChangeLogCreateDto input)
        {
            return _changeLogsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ChangeLogDto> UpdateAsync(Guid id, ChangeLogUpdateDto input)
        {
            return _changeLogsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _changeLogsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ChangeLogExcelDownloadDto input)
        {
            return _changeLogsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _changeLogsAppService.GetDownloadTokenAsync();
        }
    }
}