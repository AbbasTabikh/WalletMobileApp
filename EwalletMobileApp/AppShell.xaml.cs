using EwalletMobileApp.MVVM.Views;

namespace EwalletMobileApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SingleBudgetView), typeof(SingleBudgetView));
        }
    }
}
