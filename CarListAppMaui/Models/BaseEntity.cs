using SQLite;

namespace CarListAppMaui.Models
{
    public abstract class BaseEntity
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

    }
}
