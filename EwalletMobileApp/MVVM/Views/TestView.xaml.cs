using EwalletMobileApp.MVVM.ViewModels;
using EwalletMobileApp.Services;

namespace EwalletMobileApp.MVVM.Views;

public partial class TestView : ContentPage
{
    public TestView()
    {
        InitializeComponent();
        BindingContext = new BudgetsViewModel(new NavigationService());
    }
}