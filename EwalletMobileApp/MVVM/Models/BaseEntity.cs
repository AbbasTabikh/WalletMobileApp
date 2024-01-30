using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace EwalletMobileApp.MVVM.Models
{
    public class BaseEntity : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime CreationDate { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public virtual void SetCreationDate()
        {
            CreationDate = DateTime.UtcNow;
        }
    }
}
