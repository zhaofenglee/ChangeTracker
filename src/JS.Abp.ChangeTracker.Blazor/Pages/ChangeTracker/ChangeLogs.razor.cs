using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.DataGrid;
using Volo.Abp.BlazoriseUI.Components;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using JS.Abp.ChangeTracker.ChangeLogs;
using JS.Abp.ChangeTracker.Permissions;
using JS.Abp.ChangeTracker.Shared;

namespace JS.Abp.ChangeTracker.Blazor.Pages.ChangeTracker
{
    public partial class ChangeLogs
    {
        protected List<Volo.Abp.BlazoriseUI.BreadcrumbItem> BreadcrumbItems = new List<Volo.Abp.BlazoriseUI.BreadcrumbItem>();
        protected PageToolbar Toolbar {get;} = new PageToolbar();
        private IReadOnlyList<ChangeLogDto> ChangeLogList { get; set; }
        private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
        private int CurrentPage { get; set; } = 1;
        private string CurrentSorting { get; set; } = string.Empty;
        private int TotalCount { get; set; }
        private bool CanCreateChangeLog { get; set; }
        private bool CanEditChangeLog { get; set; }
        private bool CanDeleteChangeLog { get; set; }
        private ChangeLogCreateDto NewChangeLog { get; set; }
        private Validations NewChangeLogValidations { get; set; } = new();
        private ChangeLogUpdateDto EditingChangeLog { get; set; }
        private Validations EditingChangeLogValidations { get; set; } = new();
        private Guid EditingChangeLogId { get; set; }
        private Modal CreateChangeLogModal { get; set; } = new();
        private Modal EditChangeLogModal { get; set; } = new();
        private GetChangeLogsInput Filter { get; set; }
        private DataGridEntityActionsColumn<ChangeLogDto> EntityActionsColumn { get; set; } = new();
        protected string SelectedCreateTab = "changeLog-create-tab";
        protected string SelectedEditTab = "changeLog-edit-tab";
        
        public ChangeLogs()
        {
            NewChangeLog = new ChangeLogCreateDto();
            EditingChangeLog = new ChangeLogUpdateDto();
            Filter = new GetChangeLogsInput
            {
                MaxResultCount = PageSize,
                SkipCount = (CurrentPage - 1) * PageSize,
                Sorting = CurrentSorting
            };
            ChangeLogList = new List<ChangeLogDto>();
        }

        protected override async Task OnInitializedAsync()
        {
            await SetToolbarItemsAsync();
            await SetBreadcrumbItemsAsync();
            await SetPermissionsAsync();
        }

        protected virtual ValueTask SetBreadcrumbItemsAsync()
        {
            BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:ChangeLogs"]));
            return ValueTask.CompletedTask;
        }

        protected virtual ValueTask SetToolbarItemsAsync()
        {
            Toolbar.AddButton(L["ExportToExcel"], async () =>{ await DownloadAsExcelAsync(); }, IconName.Download);
            
            Toolbar.AddButton(L["NewChangeLog"], async () =>
            {
                await OpenCreateChangeLogModalAsync();
            }, IconName.Add, requiredPolicyName: ChangeTrackerPermissions.ChangeLogs.Create);

            return ValueTask.CompletedTask;
        }

        private async Task SetPermissionsAsync()
        {
            CanCreateChangeLog = await AuthorizationService
                .IsGrantedAsync(ChangeTrackerPermissions.ChangeLogs.Create);
            CanEditChangeLog = await AuthorizationService
                            .IsGrantedAsync(ChangeTrackerPermissions.ChangeLogs.Edit);
            CanDeleteChangeLog = await AuthorizationService
                            .IsGrantedAsync(ChangeTrackerPermissions.ChangeLogs.Delete);
        }

        private async Task GetChangeLogsAsync()
        {
            Filter.MaxResultCount = PageSize;
            Filter.SkipCount = (CurrentPage - 1) * PageSize;
            Filter.Sorting = CurrentSorting;

            var result = await ChangeLogsAppService.GetListAsync(Filter);
            ChangeLogList = result.Items;
            TotalCount = (int)result.TotalCount;
        }

        protected virtual async Task SearchAsync()
        {
            CurrentPage = 1;
            await GetChangeLogsAsync();
            await InvokeAsync(StateHasChanged);
        }

        private  async Task DownloadAsExcelAsync()
        {
            var token = (await ChangeLogsAppService.GetDownloadTokenAsync()).Token;
            var remoteService = await RemoteServiceConfigurationProvider.GetConfigurationOrDefaultOrNullAsync("ChangeTracker") ??
            await RemoteServiceConfigurationProvider.GetConfigurationOrDefaultOrNullAsync("Default");
            NavigationManager.NavigateTo($"{remoteService?.BaseUrl.EnsureEndsWith('/') ?? string.Empty}api/change-tracker/change-logs/as-excel-file?DownloadToken={token}&FilterText={Filter.FilterText}", forceLoad: true);
        }

        private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<ChangeLogDto> e)
        {
            CurrentSorting = e.Columns
                .Where(c => c.SortDirection != SortDirection.Default)
                .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
                .JoinAsString(",");
            CurrentPage = e.Page;
            await GetChangeLogsAsync();
            await InvokeAsync(StateHasChanged);
        }

        private async Task OpenCreateChangeLogModalAsync()
        {
            NewChangeLog = new ChangeLogCreateDto{
                
                
            };
            await NewChangeLogValidations.ClearAll();
            await CreateChangeLogModal.Show();
        }

        private async Task CloseCreateChangeLogModalAsync()
        {
            NewChangeLog = new ChangeLogCreateDto{
                
                
            };
            await CreateChangeLogModal.Hide();
        }

        private async Task OpenEditChangeLogModalAsync(ChangeLogDto input)
        {
            var changeLog = await ChangeLogsAppService.GetAsync(input.Id);
            
            EditingChangeLogId = changeLog.Id;
            EditingChangeLog = ObjectMapper.Map<ChangeLogDto, ChangeLogUpdateDto>(changeLog);
            await EditingChangeLogValidations.ClearAll();
            await EditChangeLogModal.Show();
        }

        private async Task DeleteChangeLogAsync(ChangeLogDto input)
        {
            await ChangeLogsAppService.DeleteAsync(input.Id);
            await GetChangeLogsAsync();
        }

        private async Task CreateChangeLogAsync()
        {
            try
            {
                if (await NewChangeLogValidations.ValidateAll() == false)
                {
                    return;
                }

                await ChangeLogsAppService.CreateAsync(NewChangeLog);
                await GetChangeLogsAsync();
                await CloseCreateChangeLogModalAsync();
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        private async Task CloseEditChangeLogModalAsync()
        {
            await EditChangeLogModal.Hide();
        }

        private async Task UpdateChangeLogAsync()
        {
            try
            {
                if (await EditingChangeLogValidations.ValidateAll() == false)
                {
                    return;
                }

                await ChangeLogsAppService.UpdateAsync(EditingChangeLogId, EditingChangeLog);
                await GetChangeLogsAsync();
                await EditChangeLogModal.Hide();                
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        private void OnSelectedCreateTabChanged(string name)
        {
            SelectedCreateTab = name;
        }

        private void OnSelectedEditTabChanged(string name)
        {
            SelectedEditTab = name;
        }
        

    }
}
