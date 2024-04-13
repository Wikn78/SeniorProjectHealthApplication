using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Newtonsoft.Json;
using OpenFoodFactsCSharp.Models;
using SeniorProjectHealthApplication.Models;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SeniorProjectHealthApplication.ViewModels
{
    public class AddFoodPageViewModel : INotifyPropertyChanged
    {
        private readonly string _categoryId;
        private readonly DatabaseManager<FoodLogCategory> _foodCatagoryDb;
        private readonly DatabaseManager<FoodItem> _foodItemDb;
        private readonly List<FoodItem> _fooditems = new List<FoodItem>();
        private readonly DatabaseManager<FoodLog> _foodLogDb;

        private int _foodCategoryId;

        private string _searchText;

        public AddFoodPageViewModel(string categoryId)
        {
            _foodCatagoryDb = LoadDatabase<FoodLogCategory>();
            _foodLogDb = LoadDatabase<FoodLog>();
            _foodItemDb = LoadDatabase<FoodItem>();
            _categoryId = categoryId;
            SearchCommand = new Command(ExecuteSearchCommand);

            SearchedFoods = new ObservableCollection<FoodItem>(_fooditems);
            _foodCategoryId = GetCategoryNumber(_categoryId);
            Preferences.Set("foodCategory_Id", _foodCategoryId);

            UpdateNutrition();


        }

        private async void UpdateNutrition()
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

        public ObservableCollection<FoodItem> SearchedFoods { get; set; }


        private async void ExecuteSearchCommand()
        {
            SearchedFoods.Clear();


            var responses = await FoodDatabaseManager.GetProductByNameAsync(SearchText);

            var foodLog = _foodLogDb.GetFoodLogInfoByDate(Preferences.Get("selectedDate", ""),
                Preferences.Get("userId", 0));
            var foodCategory = _foodCatagoryDb.GetFoodLogCategory(foodLog.FL_ID, _foodCategoryId);

            foreach (var product in responses.Products)
                SearchedFoods.Add(new FoodItem
                {
                    ProductInformation = JsonConvert.SerializeObject(product), // makes into json
                    FoodCategory = _foodCategoryId,
                    Barcode_ID = product.Id,
                    FL_ID = Preferences.Get("currentFoodCategory_Id", 0),
                    Food_Name = product.ProductName,
                    Total_Calories = (product.Nutriments.EnergyKcalServing = product.Nutriments.EnergyKcalServing) ?? 0,
                    Quantity = 1,
                    Unit_Calorie = (product.Nutriments.EnergyKcalServing = product.Nutriments.EnergyKcalServing) ?? 0
                });

            if (responses.Products.Length == 0)
            {
                // var response = await FoodDatabaseManager.GetProductByBarCodeAsync("03400908");
                // SearchedFoods.Add(new FoodItem
                // {
                //     FoodCatagory = 1,
                //     FL_ID = foodCategory.Id,
                //     Food_Name = response.Product.ProductName,
                //     Total_Calories = (response.Product.Nutriments.EnergyKcalServing = response.Product.Nutriments.EnergyKcalServing) ?? 0,
                //     Quantity = 1,
                //     Unit_Calorie = (response.Product.Nutriments.EnergyKcalServing = response.Product.Nutriments.EnergyKcalServing) ?? 0
                // });


                SearchedFoods.Add(new FoodItem
                {
                    Food_Name = "No food found...",
                    FoodCategory = 1,
                    FL_ID = foodCategory.Id
                });
            }
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

        #region FoodThings

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

        #endregion
        
        #region Search Function

        public ICommand SearchCommand { get; private set; }

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(); // Raise a property changed event
                }
            }
        }

        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}