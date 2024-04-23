using System;
using System.ComponentModel;
using System.Windows.Input;
using SeniorProjectHealthApplication.Models;
using SeniorProjectHealthApplication.Models.Database_Structure;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SeniorProjectHealthApplication.ViewModels
{
    public class AddWorkoutModalViewModel : INotifyPropertyChanged
    {
        public AddWorkoutModalViewModel()
        {
            AddCommand = new Command(execute: async () =>
            {
                // add your logic here...

                // convert lb to kg

                int minutes = Int32.Parse(WorkoutName);
                var userId = Preferences.Get("userId", 0);

                var userInfoDb = await UserDataManager.LoadDatabase<UserAppInfo>();
                var userInfo = userInfoDb.GetUserAppInfo(userId);


                double userWeight = userInfo.Weight * 0.45359237;

                double burned = CalculateCaloriesBurned(userWeight, minutes / 60.0, GetMet());


                var workoutLogDb = await UserDataManager.LoadDatabase<WorkoutLog>();
                var currentTime = DateTime.Now.ToString("G");
                workoutLogDb.AddItem(new WorkoutLog
                {
                    TimeLogged = currentTime,
                    CaloriesBurned = (float)burned
                });

                await Application.Current.MainPage.Navigation.PopModalAsync();

                int GetMet()
                {
                    switch (SelectedType.ToLower())
                    {
                        case "low intensity":
                            return 4;
                        case "medium intensity":
                            return 7;
                        case "high intensity":
                            return 9;
                    }

                    return 0;
                }
            });
        }

        public string WorkoutName { get; set; }
        public string SelectedType { get; set; }
        public ICommand AddCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        double CalculateCaloriesBurned(double weightKg, double durationHours, double metValue)
        {
            return metValue * weightKg * durationHours;
        }
    }
}