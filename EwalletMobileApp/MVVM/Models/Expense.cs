using EwalletMobileApp.Enums;
using SQLiteNetExtensions.Attributes;

namespace EwalletMobileApp.MVVM.Models;

public class Expense : BaseEntity
{
    private double _price;
    public double Price
    {
        get
        {
            return _price;
        }
        set
        {
            SetProperty(ref _price, value);
        }
    }

    private Category _category;
    public Category Category
    {
        get
        {
            return _category;
        }
        set
        {
            SetProperty(ref _category, value);
        }
    }

    [ForeignKey(typeof(Budget))]
    public int BudgetID { get; set; }
}
