using System;
using System.Collections.Generic;
using System.IO;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        private readonly int _userId;

        public WelcomePage()
        {
            InitializeComponent();

            var userId = Xamarin.Essentials.Preferences.Get("userId", 0);

            _userId = userId;


            List<int> weightValuesPounds = new List<int>();
            for (int i = 50; i <= 400; i++)
            {
                weightValuesPounds.Add(i);
            }

            List<int> heightValuesFeet = new List<int>();
            for (int i = 2; i <= 9; i++)
            {
                heightValuesFeet.Add(i);
            }

            List<int> heightValuesInch = new List<int>();
            for (int i = 0; i <= 11; i++)
            {
                heightValuesInch.Add(i);
            }


            GoalWeight.ItemsSource = weightValuesPounds;
            CurrentWeight.ItemsSource = weightValuesPounds;


            HeightFeet.ItemsSource = heightValuesFeet;
            HeightInch.ItemsSource = heightValuesInch;
        }

        private async void UpdateGoals_Clicked(object sender, EventArgs e)
        {
            DatabaseManager<UserAppInfo> userAppInfoDb = LoadUserAppInfoDatabase();

            int height = (int.Parse(HeightFeet.SelectedItem.ToString()) * 12) +
                         int.Parse(HeightInch.SelectedItem.ToString());


            userAppInfoDb.AddItem(new UserAppInfo
            {
                Date = DateTime.Now.ToString(),
                UID = _userId,
                Height = height,
                Weight = int.Parse(CurrentWeight.SelectedItem.ToString()),
                GoalWeight = int.Parse(GoalWeight.SelectedItem.ToString())
            });


            await Navigation.PushAsync(new DashboardPage());
        }


        private DatabaseManager<UserAppInfo> LoadUserAppInfoDatabase()
        {
            string fileName = "Database.db3";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(folderPath, fileName);

            return new DatabaseManager<UserAppInfo>(dbPath);
        }
    }
}