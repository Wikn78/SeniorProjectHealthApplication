using SQLite;

namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class FoodLogCategory
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; }
        public int FL_ID { get; set; }

        public int FoodCatagory { get; set; }
    }
}