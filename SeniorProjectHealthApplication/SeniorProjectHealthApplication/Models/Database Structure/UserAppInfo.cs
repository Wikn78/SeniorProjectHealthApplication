using SQLite;

namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class UserAppInfo
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; }

        public int UID { get; set; }
        public string Date { get; set; }
        public float Height { get; set; } // Stored In inchs
        public float Weight { get; set; }
        public float GoalWeight { get; set; }
    }
}