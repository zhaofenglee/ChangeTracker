using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using global::JS.Abp.ChangeTracker.ChangeLogs;
using global::JS.Abp.ChangeTracker.Localization;
using global::JS.Abp.ChangeTracker.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Components.Web;
using Blazorise;
using Blazorise.Components;
using Blazorise.DataGrid;
using Volo.Abp.BlazoriseUI;
using Volo.Abp.BlazoriseUI.Components;
using Volo.Abp.ObjectMapping;
using Volo.Abp.AspNetCore.Components.Messages;
using Volo.Abp.AspNetCore.Components.Web.Theming.Layout;
using global::JS.Abp.ChangeTracker.Permissions;
using Microsoft.AspNetCore.Components;
using Volo.Abp.AspNetCore.Components.Web;
using Volo.Abp.Http.Client;
using JS.Abp.ChangeTracker.ChangeTypes;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using AutoMapper.Internal.Mappers;

namespace JS.Abp.ChangeTracker.Blazor.Components
{
    public partial class HistoryLog
    {
        [Parameter] public Guid SystemId { get; set; }
        private bool CanReadChangeLog { get; set; }
        private IReadOnlyList<ChangeLogDto> ChangeLogList { get; set; }
        private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
        private int CurrentPage { get; set; } = 1;
        private string CurrentSorting { get; set; } = string.Empty;
        private int TotalCount { get; set; }
        private GetChangeLogsInput Filter { get; set; }

        public HistoryLog()
        {
            
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
            await SetPermissionsAsync();
        }
        private async Task SetPermissionsAsync()
        {
            CanReadChangeLog = await AuthorizationService
                .IsGrantedAsync(ChangeTrackerPermissions.ChangeLogs.Default);
        }
        private async Task GetChangeLogsAsync()
        {
            Filter.MaxResultCount = PageSize;
            Filter.SkipCount = (CurrentPage - 1) * PageSize;
            Filter.Sorting = CurrentSorting;
            Filter.SystemId = SystemId;
            var result = await ChangeLogsAppService.GetListAsync(Filter);
            ChangeLogList = result.Items;
            TotalCount = (int)result.TotalCount;
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


    }
}