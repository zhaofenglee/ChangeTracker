using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace JS.Abp.ChangeTracker.Web.Menus;

public class ChangeTrackerMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(ChangeTrackerMenus.Prefix, displayName: "ChangeTracker", "~/ChangeTracker", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
