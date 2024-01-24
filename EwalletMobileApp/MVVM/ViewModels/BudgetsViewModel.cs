using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        public ObservableCollection<Budget> Budgets { get; set; }

        [ObservableProperty]
        private double _totalSum = 0.0;

        [ObservableProperty]
        private bool _isSheetShownAlready = false;

        private BottomSheet? _budgetBottomSheet;
        public BudgetsViewModel(INavigationService navigationService) : base(navigationService)
        {
            Budgets = AddDummyData();
        }

        [RelayCommand]
        private async Task SelectionChanged(Budget selectedItem)
        {
            await _navigationService.NavigateTo(nameof(SingleBudgetView),
                                                                new Dictionary<string, object> { { "selectedBudget", selectedItem } });
        }

        [RelayCommand]
        private void CreateBudget()
        {
            Budgets.Add(new Budget
            {
                CreationDate = DateTime.UtcNow,
                ID = Budgets.Count,
                Total = TotalSum
            });


        }

        [RelayCommand]
        private void Add(string value)
        {
            if (double.TryParse(value, out double valueAsDouble))
            {
                TotalSum += valueAsDouble;
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

        private ObservableCollection<Budget> AddDummyData()
        {
            return new ObservableCollection<Budget>()
            {
                new Budget
                {
                    ID = 1,
                    Expenses = null,
                    CreationDate = DateTime.Now,
                    Total = 15005
                },
                new Budget
                {
                    ID = 2,
                    Expenses = null,
                    CreationDate = DateTime.Now,
                    Total = 15010
                },
                new Budget
                {
                    ID = 3,
                    Expenses = null,
                    CreationDate = DateTime.Now,
                    Total = 15000
                },new Budget
                {
                    ID = 4,
                    Expenses = null,
                    CreationDate = DateTime.Now,
                    Total = 1200
                },new Budget
                {
                    ID = 5,
                    Expenses = null,
                    CreationDate = DateTime.Now,
                    Total = 1500
                },new Budget
                {
                    ID = 6,
                    Expenses = null,
                    CreationDate = DateTime.Now,
                    Total = 150064
                },
            };
        }
    }
}
