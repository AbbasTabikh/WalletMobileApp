using EwalletMobileApp.Enums;
using EwalletMobileApp.MVVM.Models;
using EwalletMobileApp.Services.Interfaces;
using System.Collections.ObjectModel;

namespace EwalletMobileApp.MVVM.ViewModels
{
    public partial class SingleBudgetViewModel : ViewModelBase
    {
        public ObservableCollection<Expense> Expenses { get; set; }

        public SingleBudgetViewModel(INavigationService navigationService) : base(navigationService)
        {
            Expenses = AddDummyData();
        }

        private ObservableCollection<Expense> AddDummyData()
        {
            return
            [
                new Expense
                {
                    Price = 26236.22,
                    ID = 1,
                    CreationDate = DateTime.Now,
                    Category = Category.Education,
                    Name = "Expense Name"
                },
                new Expense
                {
                    Price = 26236,
                    ID = 2,
                    CreationDate = DateTime.Now,
                    Category = Category.Transportation,
                    Name = "Expense Name"
                },
                new Expense
                {
                    Price = 26236,
                    Name = "Expense Name",
                    ID = 3,
                    CreationDate = DateTime.Now,
                    Category = Category.Transportation
                },new Expense
                {
                    Name = "Expense Name",
                    Price = 26236,
                    ID = 4,
                    CreationDate = DateTime.Now,
                    Category = Category.Transportation
                },new Expense
                {
                    Name = "Expense Name",
                    Price = 26236.23,
                    ID = 5,
                    CreationDate = DateTime.Now,
                    Category = Category.Other
                },new Expense
                {
                    Name = "Expense Name",
                    Price = 26236,
                    ID = 6,
                    CreationDate = DateTime.Now,
                    Category = Category.Savings
                },
            ];
        }

    }
}
