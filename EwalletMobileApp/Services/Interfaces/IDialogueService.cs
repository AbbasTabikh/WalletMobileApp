using CommunityToolkit.Maui.Views;

namespace EwalletMobileApp.Services.Interfaces
{
    public interface IDialogueService
    {
        Task Open(Popup popup);
        Task Close(Popup popup);
    }
}
