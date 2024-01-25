using EwalletMobileApp.MVVM.ViewModels;
using System.Diagnostics;

namespace EwalletMobileApp.MVVM.Views;

public partial class BudgetsView : ContentPage
{
    private readonly BudgetsViewModel _viewModel;

    public BudgetsView(BudgetsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            if (_viewModel.LoadBudgetsOnStartCommand.CanExecute(null))
            {
                await _viewModel.LoadBudgetsOnStartCommand.ExecuteAsync(null);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}