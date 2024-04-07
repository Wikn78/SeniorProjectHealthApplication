using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using OpenFoodFactsCSharp.Clients;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using Xamarin.Essentials;

namespace SeniorProjectHealthApplication.ViewModels
{
    public sealed class FoodCategoryViewModel : INotifyPropertyChanged
    {
        private readonly string _categoryId;
        private readonly DatabaseManager<FoodLogCategory> _foodCatagoryDb;
        private readonly DatabaseManager<FoodItem> _foodItemDb;
        private readonly DatabaseManager<FoodLog> _foodLogDb;
        private readonly FoodLogCategory foodCategory;
        private readonly FoodLog foodLog;

        public FoodCategoryViewModel(string categoryId)
        {
            // Load your databases


            _foodCatagoryDb = LoadDatabase<FoodLogCategory>();
            _foodLogDb = LoadDatabase<FoodLog>();
            _foodItemDb = LoadDatabase<FoodItem>();
            // set current categoryID
            if (GetCategoryNumber(categoryId) == 0)
            {
                _categoryId = Preferences.Get("categoryId", "");
            }
            else
            {
                Preferences.Set("categoryId", categoryId);
                _categoryId = categoryId;
            }


            // Fetch your data
            foodLog = _foodLogDb.GetFoodLogInfoByDate(Preferences.Get("selectedDate", ""),
                Preferences.Get("userId", 0));
            foodCategory = _foodCatagoryDb.GetFoodLogCategory(foodLog.FL_ID, GetCategoryNumber(_categoryId));

            //AddFoodProductDebug();

            // Add a food item for testing


            // Load your food items
            var foodItems = _foodCatagoryDb.GetFoodItems(foodCategory.Id, foodCategory.FoodCatagory);

            // Assign to your ObservableCollection
            FoodItems = new ObservableCollection<FoodItem>(foodItems);
        }

        public ObservableCollection<FoodItem> FoodItems { get; set; }

        // Implement Property Changed Event
        public event PropertyChangedEventHandler PropertyChanged;


        private async Task AddFoodProductDebug()
        {
            var wrapper = new OpenFoodFactsApiLowLevelClient();

            var productResponse = await wrapper.FetchProductByCodeAsync("01289903"); // 034856890089 welech fruit snacks

            _foodItemDb.AddItem(new FoodItem
            {
                FL_ID = foodCategory.Id,
                Food_Name = productResponse.Product.ProductName,
                Unit_Calorie = (float)productResponse.Product.Nutriments.EnergyKcalServing,
                Quantity = 2,
                FoodCatagory = 1,
                Total_Calories = (float)productResponse.Product.Nutriments.EnergyKcalServing * 2
            });

            var projectResponses = await wrapper.FetchProductsByNameAsync("chicken");

            Console.Write(projectResponses.PageCount);
        }

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
            var fileName = "Database.db3";
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var dbPath = Path.Combine(folderPath, fileName);

            return new DatabaseManager<T>(dbPath);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RemoveFoodItem(FoodItem item)
        {
            FoodItems.Remove(item);
            // since you are using DatabaseManager to interact with your database,
            // I guess you also need to remove this item from the database
            // _foodItemDb.DeleteItem(item);
        }
    }
}