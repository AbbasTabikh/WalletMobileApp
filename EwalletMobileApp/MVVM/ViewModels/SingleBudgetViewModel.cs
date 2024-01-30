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
        private readonly IDialogueService _dialogueService;
        private readonly IExpenseService _expenseService;
        private readonly IBudgetService _budgetService;
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

        [ObservableProperty]
        private Expense _newExpense = new();

        [ObservableProperty]
        private ObservableCollection<Expense>? _expenses = null;

        [ObservableProperty]
        private double _wasted;

        private Budget _selectedBudget;
        public Budget SelectedBudget
        {
            get { return _selectedBudget; }
            set
            {
                _selectedBudget = value;
                NewExpense.BudgetID = value.ID;
                if (Expenses is null)
                {
                    Task.Run(async () => await LoadExpenses(_selectedBudget));
                }
                OnPropertyChanged(nameof(SelectedBudget));
            }
        }

        private async Task LoadExpenses(Budget budget)
        {
            Expenses = [];
            if (budget is not null)
            {
                var requiredExpenses = await _expenseService.GetAll(budget.ID, CancellationToken.None);
                if (requiredExpenses != null && requiredExpenses.Any())
                {
                    Expenses = new ObservableCollection<Expense>(requiredExpenses);
                    Wasted = Expenses.Sum(x => x.Price);
                }
            }
        }

        public SingleBudgetViewModel(INavigationService navigationService,
                                                IDialogueService dialogueService,
                                                IExpenseService expenseService,
                                                IBudgetService budgetService) : base(navigationService)
        {
            _dialogueService = dialogueService;
            _expenseService = expenseService;
            _budgetService = budgetService;
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
            UpdateWastedText(NewExpense.Price);
            Expenses.Add(NewExpense);
        }

        [RelayCommand]
        private async Task DeleteExpense(Expense expense)
        {
            await _expenseService.Delete(expense);
            Expenses.Remove(expense);
            UpdateWastedText(-expense.Price);
        }

        [RelayCommand]
        private async Task UpdateBudget()
        {
            await _budgetService.Update(SelectedBudget, CancellationToken.None);
            OnPropertyChanged(nameof(SelectedBudget));
        }

        [RelayCommand]
        private async Task OpenEditBudgetDialogue()
        {
            var dialogue = DialogueFactory.CreateInstance<EditBudgetDialogue, SingleBudgetViewModel>(this);
            await _dialogueService.Open(dialogue);
        }
        private void UpdateWastedText(double price)
        {
            Wasted += price;
        }
    }
}
