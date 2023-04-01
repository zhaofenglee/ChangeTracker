using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace JS.Abp.ChangeTracker.Pages;

public class IndexModel : ChangeTrackerPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
