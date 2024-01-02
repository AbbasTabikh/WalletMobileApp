using SQLiteNetExtensions.Attributes;

namespace EwalletMobileApp.MVVM.Models;

public class Budget : BaseEntity
{   
    public double Total { get; set; }

    [OneToMany(CascadeOperations = CascadeOperation.All)]
    public ICollection<Expense>? Expenses { get; set; }

    public override void SetCreationDate()
    {
        if (Expenses is not null && Expenses.Count is not 0)
        {
            foreach (var expense in Expenses)
            {
                expense.SetCreationDate();
            }
        }
    }
}
