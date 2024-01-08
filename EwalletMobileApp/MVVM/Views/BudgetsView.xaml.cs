using EwalletMobileApp.MVVM.ViewModels;

namespace EwalletMobileApp.MVVM.Views;

public partial class BudgetsView : ContentPage
{
	public BudgetsView(BudgetsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}