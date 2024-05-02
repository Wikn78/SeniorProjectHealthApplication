using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenFoodFactsCSharp.Clients;
using OpenFoodFactsCSharp.Models;
using SeniorProjectHealthApplication.Models;
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
            Preferences.Set("currentFoodCategory_Id", foodCategory.Id);
            
            // Load your food items
            var foodItems = _foodCatagoryDb.GetFoodItems(foodCategory.Id, foodCategory.FoodCatagory);

            // Assign to your ObservableCollection
            FoodItems = new ObservableCollection<FoodItem>(foodItems);

            SetFoodInfo();



        }


        private async void SetFoodInfo()
        {
            var foodItems = new List<FoodItem>();
            var foodItemsDb = await UserDataManager.LoadDatabase<FoodItem>();
            int CurrentFoodLog = Preferences.Get("CurrentFoodLog", 0);
            var foodCategoryDb = await UserDataManager.LoadDatabase<FoodLogCategory>();
            var foodCategory = foodCategoryDb.GetAllItems().Where(x => x.FL_ID == CurrentFoodLog).Where(x => x.FoodCatagory == GetCategoryNumber(_categoryId));
            
            foreach (var category in foodCategory)
            {
                var items = foodItemsDb.GetAllItems().Where(x => x.FL_ID == category.Id);
                foodItems.AddRange(items);
            }

            float totalCals = 0, totalProtein= 0, totalCarbs= 0, totalFat= 0;
            
            foreach (var foodItem in foodItems)
            {
                var product = JsonConvert.DeserializeObject<Product>(foodItem.ProductInformation);
                totalCals += (product.Nutriments.EnergyKcalServing ?? 0) * foodItem.Quantity;
                totalProtein += (product.Nutriments.ProteinsServing ?? 0) * foodItem.Quantity;
                totalCarbs += (product.Nutriments.CarbohydratesServing ?? 0) * foodItem.Quantity;
                totalFat += (product.Nutriments.FatServing ?? 0) * foodItem.Quantity;
                
            }

            TotalCalories = totalCals.ToString("f0") + " cals";
            TotalProtein = totalProtein.ToString("f0") + " g";
            TotalCarbs = totalCarbs.ToString("f0") + " g";
            TotalFats = totalFat.ToString("f0") + " g";

        }
        
        
        private string _totalCalories;
        public string TotalCalories
        {
            get => _totalCalories;
            set
            {
                _totalCalories = value;
                OnPropertyChanged(nameof(TotalCalories)); // Notify UI of value change
            }
        }
        
        private string _totalCarbs;
        public string TotalCarbs
        {
            get => _totalCarbs;
            set
            {
                _totalCarbs = value;
                OnPropertyChanged(nameof(TotalCarbs)); // Notify UI of value change
            }
        }
        
        private string _totalFats;
        public string TotalFats
        {
            get => _totalFats;
            set
            {
                _totalFats = value;
                OnPropertyChanged(nameof(TotalFats)); // Notify UI of value change
            }
        }
        
        private string _totalProtein;
        public string TotalProtein
        {
            get => _totalProtein;
            set
            {
                _totalProtein = value;
                OnPropertyChanged(nameof(TotalProtein)); // Notify UI of value change
            }
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