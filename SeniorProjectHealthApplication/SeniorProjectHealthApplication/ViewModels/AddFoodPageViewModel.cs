using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Newtonsoft.Json;
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