using JS.Abp.ChangeTracker.Web.Pages.ChangeTracker.ChangeLogs;
using Volo.Abp.AutoMapper;
using JS.Abp.ChangeTracker.ChangeLogs;
using AutoMapper;

namespace JS.Abp.ChangeTracker.Web;

public class ChangeTrackerWebAutoMapperProfile : Profile
{
    public ChangeTrackerWebAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<ChangeLogDto, ChangeLogUpdateViewModel>();
        CreateMap<ChangeLogUpdateViewModel, ChangeLogUpdateDto>();
        CreateMap<ChangeLogCreateViewModel, ChangeLogCreateDto>();
    }
}