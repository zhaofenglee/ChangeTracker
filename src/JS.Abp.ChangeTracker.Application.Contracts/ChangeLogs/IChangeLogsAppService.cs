using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using JS.Abp.ChangeTracker.Shared;

namespace JS.Abp.ChangeTracker.ChangeLogs
{
    public interface IChangeLogsAppService : IApplicationService
    {
        Task<PagedResultDto<ChangeLogDto>> GetListAsync(GetChangeLogsInput input);

        Task<ChangeLogDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ChangeLogDto> CreateAsync(ChangeLogCreateDto input);

        Task<ChangeLogDto> UpdateAsync(Guid id, ChangeLogUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ChangeLogExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}