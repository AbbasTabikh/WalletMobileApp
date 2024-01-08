using CommunityToolkit.Mvvm.Input;
using EwalletMobileApp.MVVM.Models;
using EwalletMobileApp.MVVM.Views;
using EwalletMobileApp.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EwalletMobileApp.MVVM.ViewModels
{
    public partial class BudgetsViewModel : ViewModelBase
    {
        public ObservableCollection<Budget> Budgets { get; set; } 
        public BudgetsViewModel(INavigationService navigationService) : base(navigationService)
        {
            Budgets = AddDummyData();
        }


        [RelayCommand]
        private async Task BudgetSelected()
        {
            await _navigationService.NavigateTo(nameof(SingleBudgetView), null);
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
