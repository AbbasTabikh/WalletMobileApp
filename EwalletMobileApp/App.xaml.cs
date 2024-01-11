using EwalletMobileApp.MVVM.ViewModels;
using EwalletMobileApp.MVVM.Views;
using EwalletMobileApp.Services;

namespace EwalletMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SingleBudgetView(new SingleBudgetViewModel(new NavigationService(), new DialogueService()));
        }
    }
}
