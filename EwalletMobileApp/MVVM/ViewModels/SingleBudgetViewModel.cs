﻿using EwalletMobileApp.Enums;
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
                    ID = 1,
                    CreationDate = DateTime.Now,
                    Category = Category.Education,
                    Name = "Expense Name"
                },
                new Expense
                {
                    ID = 2,
                    CreationDate = DateTime.Now,
                    Category = Category.Transportation,
                    Name = "Expense Name"
                },
                new Expense
                {
                    Name = "Expense Name",
                    ID = 3,
                    CreationDate = DateTime.Now,
                    Category = Category.Transportation
                },new Expense
                {
                    Name = "Expense Name",

                    ID = 4,
                    CreationDate = DateTime.Now,
                    Category = Category.Transportation
                },new Expense
                {
                    Name = "Expense Name",

                    ID = 5,
                    CreationDate = DateTime.Now,
                    Category = Category.Other
                },new Expense
                {
                    Name = "Expense Name",

                    ID = 6,
                    CreationDate = DateTime.Now,
                    Category = Category.Savings
                },
            ];
        }

    }
}
