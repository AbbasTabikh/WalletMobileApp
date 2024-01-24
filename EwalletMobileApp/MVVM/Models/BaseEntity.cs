using SQLite;

namespace EwalletMobileApp.MVVM.Models
{
    public class BaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime CreationDate { get; set; }

        public string Name { get; set; } = "Newly created";

        public virtual void SetCreationDate()
        {
            CreationDate = DateTime.UtcNow;
        }
    }
}
