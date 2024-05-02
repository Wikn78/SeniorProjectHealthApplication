using SQLite;

namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class FoodItem
    {
        [PrimaryKey] [AutoIncrement] public int FI_ID { get; set; }

        public int FL_ID { get; set; }
        public string Barcode_ID { get; set; }
        public string ProductInformation { get; set; }
        public string FoodItemJson { get; set; }
        public int FoodCategory { get; set; }
        public string Food_Name { get; set; }

        public float Unit_Calorie { get; set; }
        public float Total_Calories { get; set; }
        public float Quantity { get; set; }
    }
}