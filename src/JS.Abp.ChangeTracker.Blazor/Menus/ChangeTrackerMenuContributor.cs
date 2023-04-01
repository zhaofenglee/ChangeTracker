using JS.Abp.ChangeTracker.Permissions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using JS.Abp.ChangeTracker.Localization;
using Volo.Abp.UI.Navigation;

namespace JS.Abp.ChangeTracker.Blazor.Menus;

public class ChangeTrackerMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
       
        //var moduleMenu = AddModuleMenuItem(context);
        //AddMenuItemChangeLogs(context, moduleMenu);
    }

    private static async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        var l = context.GetLocalizer<ChangeTrackerResource>();
        var administration = context.Menu.GetAdministration();
        administration.AddItem(
            new ApplicationMenuItem(
                Menus.ChangeTrackerMenus.ChangeLogs,
                context.GetLocalizer<ChangeTrackerResource>()["Menu:ChangeLogs"],
                "/ChangeTracker/ChangeLogs",
                icon: "fa fa-file-alt",
                requiredPermissionName: ChangeTrackerPermissions.ChangeLogs.Default
            )
        );
        //administration.AddItem(new ApplicationMenuItem(ChangeTrackerMenus.Prefix, displayName: "Sample Page", "/ChangeTracker", icon: "fa fa-globe"));

        await Task.CompletedTask;
    }
    private static ApplicationMenuItem AddModuleMenuItem(MenuConfigurationContext context)
    {
        var moduleMenu = new ApplicationMenuItem(
            ChangeTrackerMenus.Prefix,
            context.GetLocalizer<ChangeTrackerResource>()["Menu:ChangeTracker"],
            icon: "fa fa-folder"
        );

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