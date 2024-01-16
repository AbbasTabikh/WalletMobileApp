using CommunityToolkit.Maui.Views;
using EwalletMobileApp.MVVM.ViewModels;

namespace EwalletMobileApp.Services.Factories
{
    public abstract class DialogueFactory
    {
        public static Popup CreateInstance<T, TViewModel>(ViewModelBase viewModel) where T : Popup, new() where TViewModel : ViewModelBase
        {
            T t = new();
            t.BindingContext = (TViewModel)viewModel;
            return t;
        }
    }
}
