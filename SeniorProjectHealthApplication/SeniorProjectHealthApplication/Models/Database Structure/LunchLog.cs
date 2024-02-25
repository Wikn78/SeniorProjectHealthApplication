using SQLite;

namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class LunchLog
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; }

        public int FL_ID { get; set; }
        public string Food_Name { get; set; }
        public float Quanity { get; set; }
    }
}