using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EwalletMobileApp.Enums;
using EwalletMobileApp.MVVM.Models;
using EwalletMobileApp.MVVM.Views;
using EwalletMobileApp.Services.Factories;
using EwalletMobileApp.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace EwalletMobileApp.MVVM.ViewModels
{
    [QueryProperty(nameof(SelectedBudget), "SelectedBudget")]
    public partial class SingleBudgetViewModel : ViewModelBase
    {
        [ObservableProperty]
        private Budget _selectedBudget;

        [ObservableProperty]
        private Expense _expense = new();

        public ObservableCollection<Expense> Expenses { get; set; } = new ObservableCollection<Expense>();
        private readonly IDialogueService _dialogueService;
        private readonly IExpenseService _expenseService;

        public string[] Categories { get; } = ["Food",
            "Shopping",
            "Transportation",
            "Entertainment",
            "Travel",
            "Savings",
            "Health",
            "Housing",
            "Education",
            "Utilities",
            "Other"];

        public SingleBudgetViewModel(INavigationService navigationService,
                                                IDialogueService dialogueService,
                                                IExpenseService expenseService) : base(navigationService)
        {
            _dialogueService = dialogueService;
            _expenseService = expenseService;

            _ = GetRequiredExpenses();
        }


        private async Task GetRequiredExpenses()
        {
            if (SelectedBudget == null)
            {
                Debug.WriteLine("laskjdaskljdaskjdlaskjdlaskjdlkasjdlkasjlkdjaskd");
            }
            //var requiredExpenses = await _expenseService.GetAll(SelectedBudget.ID, CancellationToken.None);
            //if (requiredExpenses != null && requiredExpenses.Any())
            //{
            //    Expenses = new ObservableCollection<Expense>(requiredExpenses);
            //}
        }

        [RelayCommand]
        private async Task OpenDialogue()
        {
            var dialogue = DialogueFactory.CreateInstance<ExpenseDialogue, SingleBudgetViewModel>(this);
            await _dialogueService.Open(dialogue);
        }



        [RelayCommand]
        private void AddExpense()
        {
            //validation goes here..
            Expenses.Add(Expense);
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
                },
                new Expense
                {
                    Name = "Expense Name",
                    Price = 26236,
                    ID = 4,
                    CreationDate = DateTime.Now,
                    Category = Category.Transportation
                },
                new Expense
                {
                    Name = "Expense Name",
                    Price = 26236.23,
                    ID = 5,
                    CreationDate = DateTime.Now,
                    Category = Category.Other
                },
                new Expense
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
