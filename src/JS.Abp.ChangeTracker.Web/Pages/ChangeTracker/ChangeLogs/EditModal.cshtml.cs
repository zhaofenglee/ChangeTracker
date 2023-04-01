using JS.Abp.ChangeTracker.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using JS.Abp.ChangeTracker.ChangeLogs;

namespace JS.Abp.ChangeTracker.Web.Pages.ChangeTracker.ChangeLogs
{
    public class EditModalModel : ChangeTrackerPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public ChangeLogUpdateViewModel ChangeLog { get; set; }

        private readonly IChangeLogsAppService _changeLogsAppService;

        public EditModalModel(IChangeLogsAppService changeLogsAppService)
        {
            _changeLogsAppService = changeLogsAppService;

            ChangeLog = new();
        }

        public async Task OnGetAsync()
        {
            var changeLog = await _changeLogsAppService.GetAsync(Id);
            ChangeLog = ObjectMapper.Map<ChangeLogDto, ChangeLogUpdateViewModel>(changeLog);

        }

        public async Task<NoContentResult> OnPostAsync()
        {

            await _changeLogsAppService.UpdateAsync(Id, ObjectMapper.Map<ChangeLogUpdateViewModel, ChangeLogUpdateDto>(ChangeLog));
            return NoContent();
        }
    }

    public class ChangeLogUpdateViewModel : ChangeLogUpdateDto
    {
    }
}