using SQLite;

namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class ExerciseDatabase
    {
        public string Exercise_Name { get; set; }
        [PrimaryKey]
        [AutoIncrement]
        public int Exercise_Id { get; set;}

        public string Exercise_Link { get; set; }

      
    }
}