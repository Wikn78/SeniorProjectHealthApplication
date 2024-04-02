using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;

namespace SeniorProjectHealthApplication.ViewModels
{
    public sealed class FoodCategoryViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseManager<FoodLogCategory> _foodCatagoryDb;
        private readonly DatabaseManager<FoodItem> _foodItemDb;
        private readonly DatabaseManager<FoodLog> _foodLogDb;

        public FoodCategoryViewModel(string categoryId)
        {
            // Load your databases
            _foodCatagoryDb = LoadDatabase<FoodLogCategory>();
            _foodLogDb = LoadDatabase<FoodLog>();
            _foodItemDb = LoadDatabase<FoodItem>();

            // Fetch your data
            var foodLog = _foodLogDb.GetFoodLogInfoByDate(Xamarin.Essentials.Preferences.Get("selectedDate", ""),
                Xamarin.Essentials.Preferences.Get("userId", 0));
            var foodCategory = _foodCatagoryDb.GetFoodLogCategory(foodLog.FL_ID, GetCategoryNumber(categoryId));

            // Add a food item for testing
            _foodItemDb.AddItem(new FoodItem
            {
                FL_ID = foodCategory.Id,
                Food_Name = "Eggs",
                Unit_Calorie = 70,
                Quantity = 3,
                FoodCatagory = 1,
                Total_Calorie = 70 * 3
            });

            // Load your food items
            var foodItems = _foodCatagoryDb.GetFoodItems(foodCategory.Id, foodCategory.FoodCatagory);

            // Assign to your ObservableCollection
            FoodItems = new ObservableCollection<FoodItem>(foodItems);
        }

        public ObservableCollection<FoodItem> FoodItems { get; set; }

        // Implement Property Changed Event
        public event PropertyChangedEventHandler PropertyChanged;

        private static int GetCategoryNumber(string categoryID)
        {
            switch (categoryID)
            {
                case "breakfast":
                    return 1;
                case "lunch":
                    return 2;
                case "dinner":
                    return 3;
                case "snack":
                    return 4;
                default:
                    return 0; // Default case if none of the above matches
            }
        }

        private DatabaseManager<T> LoadDatabase<T>() where T : new()
        {
            string fileName = "Database.db3";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(folderPath, fileName);

            return new DatabaseManager<T>(dbPath);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}