using EwalletMobileApp.MVVM.ViewModels;
using EwalletMobileApp.MVVM.Views;
using SQLite;

namespace EwalletMobileApp
{
    public partial class App : Application
    {
        public App(BudgetsViewModel viewModel)
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
