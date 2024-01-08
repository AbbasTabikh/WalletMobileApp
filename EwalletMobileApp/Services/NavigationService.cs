using EwalletMobileApp.Services.Interfaces;

namespace EwalletMobileApp.Services;

public class NavigationService : INavigationService
{
    public async Task NavigateTo(string url, IDictionary<string, object>? data)
    {
        var currentShell = Shell.Current;

        if (data is null)
        {
            await currentShell.GoToAsync(url);
        }
        else
        {
            await currentShell.GoToAsync(url, data);
        }
    }
}
