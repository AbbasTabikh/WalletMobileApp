using CommunityToolkit.Maui.Views;
using EwalletMobileApp.Services.Interfaces;

namespace EwalletMobileApp.Services
{
    public class DialogueService : IDialogueService
    {
        public async Task Close(Popup? popup)
        {
            if (popup is not null)
            {
                await popup.CloseAsync();
            }
        }
        public async Task Open(Popup popup)
        {
            Page? page = Application.Current?.MainPage ?? null;
            if (page is not null)
            {
                await page.ShowPopupAsync(popup);
            }
        }
    }
}
