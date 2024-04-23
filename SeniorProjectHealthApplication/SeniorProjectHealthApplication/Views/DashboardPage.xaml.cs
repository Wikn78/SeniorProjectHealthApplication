using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenFoodFactsCSharp.Models;
using SeniorProjectHealthApplication.Models;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        private readonly int _userId;

        private DateTime _selectedDate;


        public DashboardPage()
        {
            InitializeComponent();

            var userId = Preferences.Get("userId", 0);

            _userId = userId;
            // GET THE SELECTED DATE
            _selectedDate = DateTime.Today;

            LoadFoodUserData();
        }

        private async void LoadFoodUserData()
        {
            // check if a current date has a food log, if not make one.

            var fl = await CreateFoodLogIfNotExists();

            CurrentDateLabel.Text = _selectedDate.ToShortDateString();
            // sets the current date so all pages can get it
            Preferences.Set("selectedDate", _selectedDate.ToShortDateString());


            Preferences.Set("CurrentFoodLog", fl.FL_ID);

            // gets all food and nutriontion
            var foodItems = new List<FoodItem>();
            var foodItemsDb = await UserDataManager.LoadDatabase<FoodItem>();
            var foodCategoryDb = await UserDataManager.LoadDatabase<FoodLogCategory>();
            var foodCategorys = foodCategoryDb.GetAllItems().Where(x => x.FL_ID == fl.FL_ID);

            foreach (var category in foodCategorys)
            {
                var items = foodItemsDb.GetAllItems().Where(x => x.FL_ID == category.Id);
                foodItems.AddRange(items);
            }

            // Calculate Calories and protein

            float totalCalories = 0f, totalProtein = 0f, totalCarbs = 0f, totalFat = 0f;


            foreach (var foodItem in foodItems)
            {
                var product = JsonConvert.DeserializeObject<Product>(foodItem.ProductInformation);

                totalCalories += (product.Nutriments.EnergyKcalServing ?? 0) * foodItem.Quantity;
                totalProtein += (product.Nutriments.ProteinsServing ?? 0) * foodItem.Quantity;
                totalCarbs += (product.Nutriments.CarbohydratesServing ?? 0) * foodItem.Quantity;
                totalFat += (product.Nutriments.FatServing ?? 0) * foodItem.Quantity;
            }

            var userNutDb = await UserDataManager.LoadDatabase<UserNutrition>();
            var userNut = userNutDb.GetUserNutrition(_userId);


            DatabaseManager<WorkoutLog> workoutLogDb;

            try
            {
                workoutLogDb = await UserDataManager.LoadDatabase<WorkoutLog>();
            }
            catch (Exception e)
            {
                // Handle loading database exceptions (e.g. if the database doesn't exist)
                Debug.WriteLine(e.Message);
                return;
            }

            var logs = workoutLogDb.GetAllItems();
            var currentLog = logs
                .Where(log => !string.IsNullOrEmpty(log.TimeLogged))
                .Select(log =>
                {
                    DateTime dateTime;
                    bool parseSucceed = DateTime.TryParse(log.TimeLogged, out dateTime);
                    return new { Log = log, DateTime = dateTime, ParseSucceed = parseSucceed };
                })
                .Where(t => t.ParseSucceed && t.DateTime.Date == _selectedDate.Date)
                .Select(t => t.Log)
                .ToList();
            var totalCals = currentLog.Sum(log => log.CaloriesBurned);


            // Gets BMR
            CaloriesLeft.Text = ((userNut.CaloricIntake - totalCalories) + totalCals).ToString("f0") +
                                " \n calories left";
            caloriesConsumed_Lbl.Text = totalCalories.ToString("f0") + " \nconsumed";
            caloriesBurned_lbl.Text = $"{totalCals:f0} burned";


            ProteinCount_Lbl.Text = $"{totalProtein:f0} / {userNut.ProteinIntake:f0}";
            CarbsCount_Lbl.Text = $"{totalCarbs:f0} / {userNut.CarbIntake:f0}";
            FatCount_Lbl.Text = $"{totalFat:f0} / {userNut.FatIntake:f0}";
        }

        private async Task<FoodLog> CreateFoodLogIfNotExists()
        {
            var foodLogDb = await UserDataManager.LoadDatabase<FoodLog>();

            var fl = foodLogDb.GetFoodLogInfoByDate(_selectedDate.ToShortDateString(), _userId);

            if (fl == null)
            {
                // makes new log
                foodLogDb.AddItem(new FoodLog
                {
                    UID = _userId,
                    Date = _selectedDate.ToShortDateString()
                });
                // generate food categories
                var foodLogCategoryDb =
                    await UserDataManager.LoadDatabase<FoodLogCategory>();


                fl = foodLogDb.GetFoodLogInfoByDate(_selectedDate.ToShortDateString(), _userId);

                foodLogCategoryDb.AddItem(new FoodLogCategory
                {
                    FoodCatagory = 1,
                    FL_ID = fl.FL_ID
                });

                foodLogCategoryDb.AddItem(new FoodLogCategory
                {
                    FoodCatagory = 2,
                    FL_ID = fl.FL_ID
                });

                foodLogCategoryDb.AddItem(new FoodLogCategory
                {
                    FoodCatagory = 3,
                    FL_ID = fl.FL_ID
                });

                foodLogCategoryDb.AddItem(new FoodLogCategory
                {
                    FoodCatagory = 4,
                    FL_ID = fl.FL_ID
                });


                return fl;
            }

            return fl;
        }


        private async void Account_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }


        private void DecreaseDate_Clicked(object sender, EventArgs e)
        {
            _selectedDate = _selectedDate.AddDays(-1);
            LoadFoodUserData();
        }

        private void IncreaseDate_Clicked(object sender, EventArgs e)
        {
            _selectedDate = _selectedDate.AddDays(1);
            LoadFoodUserData();
        }
    }
}