using EwalletMobileApp.MVVM.ViewModels;

namespace EwalletMobileApp.MVVM.Views;

public partial class SingleBudgetView : ContentPage
{
	public SingleBudgetView(SingleBudgetViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
	}
}