using OpenFoodFactsCSharp.Models;
using SQLite;
namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class UserNutrition
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; }
        public int Uid { get; set; }
        public string Date { get; set; }
        public string WeightPerWeek { get; set; }
        public float CaloricIntake { get; set; }
        public float ProteinIntake { get; set; }
        public float FatIntake { get; set; }
        public float CarbIntake { get; set; }
    }
}