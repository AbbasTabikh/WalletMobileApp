using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace EwalletMobileApp.MVVM.Models
{
    public class BaseEntity : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime CreationDate { get; set; }

        public string Name { get; set; }

        public virtual void SetCreationDate()
        {
            CreationDate = DateTime.UtcNow;
        }
    }
}
