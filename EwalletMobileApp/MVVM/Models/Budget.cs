using SQLiteNetExtensions.Attributes;

namespace EwalletMobileApp.MVVM.Models;

public class Budget : BaseEntity
{
    private double _total;
    public double Total
    {
        get { return _total; }
        set { SetProperty(ref _total, value); }
    }

    [OneToMany(CascadeOperations = CascadeOperation.All)]
    public ICollection<Expense>? Expenses { get; set; }

    public override void SetCreationDate()
    {
        CreationDate = DateTime.UtcNow;

        if (Expenses is not null && Expenses.Count is not 0)
        {
            foreach (var expense in Expenses)
            {
                expense.SetCreationDate();
            }
        }
    }
}
