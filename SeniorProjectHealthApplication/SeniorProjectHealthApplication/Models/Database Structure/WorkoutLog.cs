using SQLite;

namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class WorkoutLog
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; }

        public string TimeLogged { get; set; }

        public float CaloriesBurned { get; set; }
    }
}