using CommunityToolkit.Maui.Views;
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

        private Popup? _currentOpenDialogue;
        private double _oldPrice;
        private double _oldTotal;

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
        private Expense? _selectedExpense;

        [ObservableProperty]
        private ObservableCollection<Expense>? _expenses = null;

        [ObservableProperty]
        private double _wasted;

        [ObservableProperty]
        private double _available = 0;

        [ObservableProperty]
        private double _updateExpenseAvailable;


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

        [ObservableProperty]
        private bool _isAmountErrorVisible;

        [ObservableProperty]
        private bool _isBudgetAmountErrorVisible;

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
                Available = SelectedBudget.Total - Wasted;
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
            IsAmountErrorVisible = false;
            var dialogue = DialogueFactory.CreateInstance<ExpenseDialogue, SingleBudgetViewModel>(this);
            await _dialogueService.Open(dialogue);
        }

        [RelayCommand]
        private async Task AddExpense()
        {
            if (NewExpense.Price > Available)
            {
                SetAmountError(true);
                return;
            }
            await _expenseService.Create(NewExpense);
            UpdateWastedText(NewExpense.Price);
            Expenses?.Add(NewExpense);
            UpdateAvailableText(NewExpense.Price, false);
            ResetExpense();
        }

        [RelayCommand]
        private async Task DeleteExpense(Expense expense)
        {
            await _expenseService.Delete(expense);
            Expenses?.Remove(expense);
            UpdateWastedText(-expense.Price);
            UpdateAvailableText(expense.Price, true);
        }

        [RelayCommand]
        private async Task UpdateBudget()
        {
            if (SelectedBudget.Total < Wasted)
            {
                SetBudgetAmountError(true);
                SelectedBudget.Total = _oldTotal;
                return;
            }
            await _budgetService.Update(SelectedBudget, CancellationToken.None);
            OnPropertyChanged(nameof(SelectedBudget));
            await CloseCurrentOpenDialogue();
        }

        [RelayCommand]
        private async Task OpenEditExpenseDialogue(Expense expense)
        {
            SetAmountError(false);
            SelectedExpense = expense;
            _oldPrice = expense.Price;
            UpdateExpenseAvailable = Available + _oldPrice;
            var dialogue = DialogueFactory.CreateInstance<EditExpenseDialogue, SingleBudgetViewModel>(this);
            SetCurrentOpenDialogue(dialogue);
            await _dialogueService.Open(dialogue);
        }

        [RelayCommand]
        private async Task UpdateExpense()
        {
            if (SelectedExpense?.Price > UpdateExpenseAvailable)
            {
                SetAmountError(true);
                return;
            }
            await _expenseService.Update(SelectedExpense!, CancellationToken.None);
            Wasted = (Wasted - _oldPrice) + SelectedExpense!.Price;
            Available = (Available + _oldPrice) - SelectedExpense.Price;
            UpdateExpenseAvailable = (UpdateExpenseAvailable + _oldPrice) - SelectedExpense.Price;
            await CloseCurrentOpenDialogue();
        }

        [RelayCommand]
        private async Task OpenEditBudgetDialogue()
        {
            _oldTotal = SelectedBudget.Total;
            SetBudgetAmountError(false);
            var dialogue = DialogueFactory.CreateInstance<EditBudgetDialogue, SingleBudgetViewModel>(this);
            SetCurrentOpenDialogue(dialogue);
            await _dialogueService.Open(dialogue);
        }
        private void UpdateWastedText(double price)
        {
            Wasted += price;
        }
        private void UpdateAvailableText(double value, bool isExpenseDeleted)
        {
            if (isExpenseDeleted)
            {
                Available += value;
            }
            else
            {
                Available -= value;
            }
        }
        private void SetCurrentOpenDialogue(Popup popup)
        {
            _currentOpenDialogue = popup;
        }
        private async Task CloseCurrentOpenDialogue()
        {
            if (_currentOpenDialogue is not null)
            {
                await _dialogueService.Close(_currentOpenDialogue!);
            }
            _currentOpenDialogue = null;
        }
        private void ResetExpense()
        {
            NewExpense = new Expense
            {
                BudgetID = SelectedBudget.ID
            };
        }
        private void SetAmountError(bool value)
        {
            IsAmountErrorVisible = value;
        }
        private void SetBudgetAmountError(bool value)
        {
            IsBudgetAmountErrorVisible = value;
        }
    }
}
