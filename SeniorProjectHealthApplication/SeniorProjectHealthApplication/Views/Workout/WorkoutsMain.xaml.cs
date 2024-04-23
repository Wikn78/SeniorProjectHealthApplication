using System;
using System.Diagnostics;
using System.Linq;
using SeniorProjectHealthApplication.Models;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using SeniorProjectHealthApplication.Views.Workout;
using SeniorProjectHealthApplication.Views.Workout.Cardiovascular;
using SeniorProjectHealthApplication.Views.Workout.Flexbility_and_Balance;
using SeniorProjectHealthApplication.Views.Workout.HIIT;
using SeniorProjectHealthApplication.Views.Workout.Strength_Training;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutsPage : ContentPage
    {
        // Commands


        public WorkoutsPage()
        {
            InitializeComponent();


            LoadUserCalories();
        }

        private async void LoadUserCalories()
        {
            var userId = Preferences.Get("userId", 0);
            var userNutDb = await UserDataManager.LoadDatabase<UserNutrition>();
            var userNut = userNutDb.GetUserNutrition(userId);

            var dateString = Preferences.Get("selectedDate", DateTime.Today.ToString("d"));
            var selectedDate = DateTime.Parse(dateString);

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
                .Where(t => t.ParseSucceed && t.DateTime.Date == selectedDate.Date)
                .Select(t => t.Log)
                .ToList();
            var totalCals = currentLog.Sum(log => log.CaloriesBurned);


            Device.BeginInvokeOnMainThread(() =>
            {
                CaloriesLeft_lbl.Text = $"{(userNut.CaloricIntake + totalCals):f0}";
                CaloriesBurned_lbl.Text = $"{totalCals:f0}";
            });
        }


        private async void BodyWeight_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkoutLevels());
        }

        private async void Flexibility_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Flexiblity_Levels());
        }

        private async void HIIT_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HIIT_levels());
        }

        private async void Cardio_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cardiovascular());
        }


        private async void Strength_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Strength_Training());
        }

        private void AddWorkout_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new AddWorkoutModal());
        }
    }
}