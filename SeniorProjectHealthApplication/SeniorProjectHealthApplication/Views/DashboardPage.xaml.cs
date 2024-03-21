using System;
using System.IO;
using System.Threading.Tasks;
using SeniorProjectHealthApplication.Models;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        private readonly int _userId;

        DateTime _selectedDate;


        public DashboardPage()
        {
            InitializeComponent();

            var userId = Xamarin.Essentials.Preferences.Get("userId", 0);

            _userId = userId;
            // GET THE SELECTED DATE
            _selectedDate = DateTime.Today;

            LoadFoodUserData();
        }

        private async void LoadFoodUserData()
        {
            // check if a current date has a food log, if not make one.

            FoodLog fl = await CreateFoodLogIfNotExists();

            CurrentDateLabel.Text = _selectedDate.ToShortDateString();
            // sets the current date so all pages can get it
            Xamarin.Essentials.Preferences.Set("selectedDate", _selectedDate.ToShortDateString());

            DatabaseManager<UserAppInfo> userInfoDb = await LoadDatabase<UserAppInfo>();
            DatabaseManager<Users> usersDb = await LoadDatabase<Users>();
            UserAppInfo userInfo = userInfoDb.GetUserAppInfo(_userId);
            Users user = usersDb.GetItem(_userId);

            int age = DateTime.Today.Year - DateTime.Parse(user.Birthdate).Year;

            CaloriesLeft.Text = UserDataManager.OnGetUserBmr(user.Gender, userInfo.Height, userInfo.Weight, age, false)
                .ToString("f0");
        }

        private async Task<FoodLog> CreateFoodLogIfNotExists()
        {
            DatabaseManager<FoodLog> foodLogDb = await LoadDatabase<FoodLog>();

            FoodLog fl = foodLogDb.GetFoodLogInfoByDate(_selectedDate.ToShortDateString(), _userId);

            if (fl == null)
            {
                // makes new log
                foodLogDb.AddItem(new FoodLog
                {
                    UID = _userId,
                    Date = _selectedDate.ToShortDateString()
                });
                // generate food categories
                DatabaseManager<FoodLogCategory> foodLogCategoryDb = await LoadDatabase<FoodLogCategory>();


                fl = foodLogDb.GetFoodLogInfoByDate(_selectedDate.ToShortDateString(), _userId);

                foodLogCategoryDb.AddItem(new FoodLogCategory()
                {
                    FoodCatagory = 1,
                    FL_ID = fl.FL_ID
                });

                foodLogCategoryDb.AddItem(new FoodLogCategory()
                {
                    FoodCatagory = 2,
                    FL_ID = fl.FL_ID
                });

                foodLogCategoryDb.AddItem(new FoodLogCategory()
                {
                    FoodCatagory = 3,
                    FL_ID = fl.FL_ID
                });

                foodLogCategoryDb.AddItem(new FoodLogCategory()
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


        private Task<DatabaseManager<T>> LoadDatabase<T>() where T : new()
        {
            string fileName = "Database.db3";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(folderPath, fileName);

            return Task.FromResult(new DatabaseManager<T>(dbPath));
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