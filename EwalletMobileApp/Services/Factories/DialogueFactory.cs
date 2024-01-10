using CommunityToolkit.Maui.Views;

namespace EwalletMobileApp.Services.Factories
{
    public abstract class DialogueFactory
    {
        public static Popup CreateInstance<T>() where T : Popup, new()
        {
            return new T();
        }
    }
}
