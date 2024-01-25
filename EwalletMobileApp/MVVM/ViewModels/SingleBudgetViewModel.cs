using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EwalletMobileApp.MVVM.Models;
using EwalletMobileApp.MVVM.Views;
using EwalletMobileApp.Services.Factories;
using EwalletMobileApp.Services.Interfaces;
using System.Collections.ObjectModel;

namespace EwalletMobileApp.MVVM.ViewModels
{
    [QueryProperty(nameof(SelectedBudget), "selectedBudget")]
    public partial class SingleBudgetViewModel : ViewModelBase
    {

        private Budget _selectedBudget;

        public Budget SelectedBudget
        {
            get { return _selectedBudget; }
            set
            {
                _selectedBudget = value;
                OnPropertyChanged(nameof(SelectedBudget));
                NewExpense.BudgetID = _selectedBudget.ID;
                Task.Run(async () => await LoadExpenses(_selectedBudget));
            }
        }

        private async Task LoadExpenses(Budget budget)
        {
            if (budget is not null)
            {
                var requiredExpenses = await _expenseService.GetAll(budget.ID, CancellationToken.None);
                if (requiredExpenses != null && requiredExpenses.Any())
                {
                    Expenses = new ObservableCollection<Expense>(requiredExpenses);
                }
            }
        }

        [ObservableProperty]
        private Expense _newExpense = new();

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
        }

        [RelayCommand]
        private async Task OpenDialogue()
        {
            var dialogue = DialogueFactory.CreateInstance<ExpenseDialogue, SingleBudgetViewModel>(this);
            await _dialogueService.Open(dialogue);
        }



        [RelayCommand]
        private async Task AddExpense()
        {
            await _expenseService.Create(NewExpense);
            Expenses.Add(NewExpense);
        }
    }
}
