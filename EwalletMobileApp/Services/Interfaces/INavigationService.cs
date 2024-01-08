namespace EwalletMobileApp.Services.Interfaces;

public interface INavigationService
{
    Task NavigateTo(string url, IDictionary<string, object>? data);
}
