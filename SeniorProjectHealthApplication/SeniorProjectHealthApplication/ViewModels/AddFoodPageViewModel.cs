using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using OpenFoodFactsCSharp.Models;
using SeniorProjectHealthApplication.Models;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using Xamarin.Forms;

namespace SeniorProjectHealthApplication.ViewModels
{
    public class AddFoodPageViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseManager<FoodLogCategory> _foodCatagoryDb;
        private readonly DatabaseManager<FoodItem> _foodItemDb;
        private readonly DatabaseManager<FoodLog> _foodLogDb;
        private readonly string _categoryId;
        private List<FoodItem> _fooditems = new List<FoodItem>();
        public ICommand SearchCommand { get; private set; }
        public AddFoodPageViewModel(string categoryId)
        {
            _foodCatagoryDb = LoadDatabase<FoodLogCategory>();
            _foodLogDb = LoadDatabase<FoodLog>();
            _foodItemDb = LoadDatabase<FoodItem>();
            _categoryId = categoryId;
            SearchCommand = new Command(ExecuteSearchCommand);
            
            SearchedFoods = new ObservableCollection<FoodItem>(_fooditems);

        }
        
        
        private async void ExecuteSearchCommand()
        {
            SearchedFoods.Clear();
            MultipleProjectResponse respones = await FoodDatabaseManager.GetProductByNameAsync(SearchText);
            
            FoodLog foodLog = _foodLogDb.GetFoodLogInfoByDate(Xamarin.Essentials.Preferences.Get("selectedDate", ""),
                Xamarin.Essentials.Preferences.Get("userId", 0));
            FoodLogCategory foodCategory = _foodCatagoryDb.GetFoodLogCategory(foodLog.FL_ID, GetCategoryNumber(_categoryId));
            
            foreach (var product in respones.Products)
            {
                SearchedFoods.Add(new FoodItem
                {
                    FoodCatagory = 1,
                    FL_ID = foodCategory.Id,
                    Food_Name = product.ProductName,
                    Total_Calories = (product.Nutriments.EnergyKcalServing = product.Nutriments.EnergyKcalServing)  ?? 0,
                    Quantity = 1,
                    Unit_Calorie = (product.Nutriments.EnergyKcalServing = product.Nutriments.EnergyKcalServing)  ?? 0
                    
                    
                });
            }
            
            
            Console.WriteLine("Balls");
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
            string fileName = "Database.db3";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(folderPath, fileName);

            return new DatabaseManager<T>(dbPath);
        }
        
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText)); // Raise a property changed event
                }
            }
        }
        
        public ObservableCollection<FoodItem> SearchedFoods { get; set; }
        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        
    }
}