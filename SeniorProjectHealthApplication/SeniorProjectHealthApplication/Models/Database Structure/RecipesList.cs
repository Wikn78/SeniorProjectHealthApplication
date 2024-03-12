using SQLite;

namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class RecipesList // NEEDS TO BE CHANGED LATER ON
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; }

        public string ReceipeName { get; set; }
        public string RecipePicture { get; set; }
        public double Calories { get; set; }
        public double Carbs { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double SaturatedFat { get; set; }
        public double Sodium { get; set; }
        public double Fiber { get; set; }
        public double Sugar { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
    }
}