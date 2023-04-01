using JS.Abp.ChangeTracker.ChangeTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using JS.Abp.ChangeTracker.ChangeLogs;
using JS.Abp.ChangeTracker.Shared;

namespace JS.Abp.ChangeTracker.Web.Pages.ChangeTracker.ChangeLogs
{
    public class IndexModel : AbpPageModel
    {
        public string? UserIdFilter { get; set; }
        public string? UserNameFilter { get; set; }
        public string? DescriptionFilter { get; set; }
        public ChangeType? ChangeTypeFilter { get; set; }
        public string? SystemIDFilter { get; set; }
        public string? SystemNameFilter { get; set; }

        private readonly IChangeLogsAppService _changeLogsAppService;

        public IndexModel(IChangeLogsAppService changeLogsAppService)
        {
            _changeLogsAppService = changeLogsAppService;
        }

        public async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}