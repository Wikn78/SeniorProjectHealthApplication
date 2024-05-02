using SQLite;

namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class FoodLog
    {
        [PrimaryKey] [AutoIncrement] public int FL_ID { get; set; }

        public int UID { get; set; }
        public string Date { get; set; }
    }
}