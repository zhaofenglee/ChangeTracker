using Volo.Abp.EntityFrameworkCore.Modeling;
using JS.Abp.ChangeTracker.ChangeLogs;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace JS.Abp.ChangeTracker.EntityFrameworkCore;

public static class ChangeTrackerDbContextModelCreatingExtensions
{
    public static void ConfigureChangeTracker(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(ChangeTrackerDbProperties.DbTablePrefix + "Questions", ChangeTrackerDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
        if (builder.IsHostDatabase())
        {
            builder.Entity<ChangeLog>(b =>
{
    b.ToTable(ChangeTrackerDbProperties.DbTablePrefix + "ChangeLogs", ChangeTrackerDbProperties.DbSchema);
    b.ConfigureByConvention();
    b.Property(x => x.UserId).HasColumnName(nameof(ChangeLog.UserId));
    b.Property(x => x.UserName).HasColumnName(nameof(ChangeLog.UserName)).HasMaxLength(ChangeLogConsts.UserNameMaxLength);
    b.Property(x => x.Description).HasColumnName(nameof(ChangeLog.Description));
    b.Property(x => x.ChangeType).HasColumnName(nameof(ChangeLog.ChangeType));
    b.Property(x => x.SystemId).HasColumnName(nameof(ChangeLog.SystemId));
    b.Property(x => x.SystemName).HasColumnName(nameof(ChangeLog.SystemName)).HasMaxLength(ChangeLogConsts.SystemNameMaxLength);
});

        }
    }
}