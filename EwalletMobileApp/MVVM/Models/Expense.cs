using EwalletMobileApp.Enums;
using SQLiteNetExtensions.Attributes;

namespace EwalletMobileApp.MVVM.Models;

public class Expense : BaseEntity
{
    public double Price { get; set; }
    public Category Category { get; set; }

    [ForeignKey(typeof(Budget))]
    public int BudgetID { get; set; }
}
