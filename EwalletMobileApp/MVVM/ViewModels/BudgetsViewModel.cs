using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EwalletMobileApp.Models;
using EwalletMobileApp.MVVM.Models;
using EwalletMobileApp.MVVM.Views;
using EwalletMobileApp.Services.Factories;
using EwalletMobileApp.Services.Interfaces;
using System.Collections.ObjectModel;
using The49.Maui.BottomSheet;

namespace EwalletMobileApp.MVVM.ViewModels
{
    public partial class BudgetsViewModel : ViewModelBase
    {

        private static QueryParameters parameters = new QueryParameters
        {
            CurrentPage = 1,
            PageSize = 25
        };
        public IAsyncRelayCommand LoadBudgetsOnStartCommand { get; }
        private readonly IBudgetService _budgetService;
        public ObservableCollection<Budget> Budgets { get; set; } = [];

        [ObservableProperty]
        private Budget _newBudget = new();

        [ObservableProperty]
        private bool _isSheetShownAlready = false;

        private BottomSheet? _budgetBottomSheet;
        public BudgetsViewModel(INavigationService navigationService, IBudgetService budgetService) : base(navigationService)
        {
            _budgetService = budgetService;
            LoadBudgetsOnStartCommand = new AsyncRelayCommand(LoadRequiredBudgets);
        }

        private async Task LoadRequiredBudgets()
        {
            var requiredBudgets = await _budgetService.Get(parameters, CancellationToken.None);
            if (requiredBudgets is not null && requiredBudgets.Any())
            {
                Budgets = new ObservableCollection<Budget>(requiredBudgets);
                OnPropertyChanged(nameof(Budgets));
            }
        }
        [RelayCommand]
        private async Task SelectionChanged(Budget selectedItem)
        {
            await _navigationService.NavigateTo(nameof(SingleBudgetView),
                                                                new Dictionary<string, object> { { "selectedBudget", selectedItem } });
        }

        [RelayCommand]
        private async Task CreateBudget()
        {
            await _budgetService.Create(NewBudget);
            Budgets.Add(NewBudget);
        }

        [RelayCommand]
        private void Add(string value)
        {
            if (double.TryParse(value, out double valueAsDouble))
            {
                NewBudget.Total += valueAsDouble;
            }
        }

        [RelayCommand]
        private async Task ToggleBudgetBottomSheet()
        {
            _budgetBottomSheet ??= BottomSheetFactory.CreateInstance<BudgetBottomSheet, BudgetsViewModel>(this);

            if (IsSheetShownAlready)
            {
                await _budgetBottomSheet.DismissAsync();
            }
            else
            {
                await _budgetBottomSheet.ShowAsync();
            }

            IsSheetShownAlready = !IsSheetShownAlready;
        }
    }
}
