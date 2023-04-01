using System;
using JS.Abp.ChangeTracker.Shared;
using Volo.Abp.AutoMapper;
using JS.Abp.ChangeTracker.ChangeLogs;
using AutoMapper;

namespace JS.Abp.ChangeTracker;

public class ChangeTrackerApplicationAutoMapperProfile : Profile
{
    public ChangeTrackerApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<ChangeLog, ChangeLogDto>();
        CreateMap<ChangeLog, ChangeLogExcelDto>();
    }
}