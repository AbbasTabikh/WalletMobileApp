using EwalletMobileApp.Enums;
using SQLiteNetExtensions.Attributes;

namespace EwalletMobileApp.MVVM.Models;

public class Expense : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    Category Category { get; set; }

    [ForeignKey(typeof(Budget))]
    public Guid BudgetID { get; set; }
}
