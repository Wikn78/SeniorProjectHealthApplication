using System;
using System.IO;
using System.Threading.Tasks;
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

        DateTime selectedDate;


        public DashboardPage()
        {
            InitializeComponent();

            var userId = Xamarin.Essentials.Preferences.Get("userId", 0);

            _userId = userId;
            selectedDate = DateTime.Today;

            LoadFoodUserData();
        }

        private async void LoadFoodUserData()
        {
            // check if a current date has a food log, if not make one.

            FoodLog fl = await CreateFoodLogIfNotExists();

            CurrentDateLabel.Text = selectedDate.ToShortDateString();
            // sets the current date so all pages can get it
            Xamarin.Essentials.Preferences.Set("selectedDate", selectedDate.ToShortDateString());
        }

        private async Task<FoodLog> CreateFoodLogIfNotExists()
        {
            DatabaseManager<FoodLog> foodLogDb = await LoadDatabase<FoodLog>();

            FoodLog fl = foodLogDb.GetFoodLogInfoByDate(selectedDate.ToShortDateString());

            if (fl == null)
            {
                // makes new log
                foodLogDb.AddItem(new FoodLog
                {
                    UID = _userId,
                    Date = selectedDate.ToShortDateString()
                });
                // generate food categories
                DatabaseManager<BreakfastLog> breakfastDb = await LoadDatabase<BreakfastLog>();
                DatabaseManager<LunchLog> lunchDb = await LoadDatabase<LunchLog>();
                DatabaseManager<DinnerLog> dinnerDb = await LoadDatabase<DinnerLog>();
                DatabaseManager<SnackLog> snackDb = await LoadDatabase<SnackLog>();

                fl = foodLogDb.GetFoodLogInfoByDate(selectedDate.ToShortDateString());

                breakfastDb.AddItem(new BreakfastLog
                {
                    FL_ID = fl.FL_ID,
                });

                lunchDb.AddItem(new LunchLog
                {
                    FL_ID = fl.FL_ID,
                });

                dinnerDb.AddItem(new DinnerLog
                {
                    FL_ID = fl.FL_ID,
                });

                snackDb.AddItem(new SnackLog
                {
                    FL_ID = fl.FL_ID,
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
            selectedDate = selectedDate.AddDays(-1);
            LoadFoodUserData();
        }

        private void IncreaseDate_Clicked(object sender, EventArgs e)
        {
            selectedDate = selectedDate.AddDays(1);
            LoadFoodUserData();
        }
    }
}