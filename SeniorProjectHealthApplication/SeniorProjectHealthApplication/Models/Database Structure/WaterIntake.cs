using SQLite;

namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class WaterIntake
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; }

        public int UID { get; set; }
        public string Date { get; set; }
        public float Water_Intake { get; set; }
    }
}