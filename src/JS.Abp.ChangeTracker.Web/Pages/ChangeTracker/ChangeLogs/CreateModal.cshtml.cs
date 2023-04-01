using JS.Abp.ChangeTracker.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JS.Abp.ChangeTracker.ChangeLogs;

namespace JS.Abp.ChangeTracker.Web.Pages.ChangeTracker.ChangeLogs
{
    public class CreateModalModel : ChangeTrackerPageModel
    {
        [BindProperty]
        public ChangeLogCreateViewModel ChangeLog { get; set; }

        private readonly IChangeLogsAppService _changeLogsAppService;

        public CreateModalModel(IChangeLogsAppService changeLogsAppService)
        {
            _changeLogsAppService = changeLogsAppService;

            ChangeLog = new();
        }

        public async Task OnGetAsync()
        {
            ChangeLog = new ChangeLogCreateViewModel();

            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            await _changeLogsAppService.CreateAsync(ObjectMapper.Map<ChangeLogCreateViewModel, ChangeLogCreateDto>(ChangeLog));
            return NoContent();
        }
    }

    public class ChangeLogCreateViewModel : ChangeLogCreateDto
    {
    }
}