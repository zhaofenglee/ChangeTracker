using JS.Abp.ChangeTracker.Permissions;
using JS.Abp.ChangeTracker.Localization;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Volo.Abp.Authorization.Permissions;

namespace JS.Abp.ChangeTracker.Web.Menus;

public class ChangeTrackerMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name != StandardMenus.Main)
        {
            return;
        }

        var moduleMenu = AddModuleMenuItem(context); //Do not delete `moduleMenu` variable as it will be used by ABP Suite!

        AddMenuItemChangeLogs(context, moduleMenu);
    }

    private static ApplicationMenuItem AddModuleMenuItem(MenuConfigurationContext context)
    {
        var moduleMenu = new ApplicationMenuItem(
            ChangeTrackerMenus.Prefix,
            displayName: "ChangeTracker",
            "~/ChangeTracker",
            icon: "fa fa-globe");

        //Add main menu items.
        context.Menu.Items.AddIfNotContains(moduleMenu);
        return moduleMenu;
    }
    private static void AddMenuItemChangeLogs(MenuConfigurationContext context, ApplicationMenuItem parentMenu)
    {
        parentMenu.AddItem(
            new ApplicationMenuItem(
                Menus.ChangeTrackerMenus.ChangeLogs,
                context.GetLocalizer<ChangeTrackerResource>()["Menu:ChangeLogs"],
                "/ChangeTracker/ChangeLogs",
                icon: "fa fa-file-alt",
                requiredPermissionName: ChangeTrackerPermissions.ChangeLogs.Default
            )
        );
    }
}