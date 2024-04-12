using System;
using System.Collections.Generic;
using System.IO;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using Xamarin.Essentials;
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

            var userId = Preferences.Get("userId", 0);

            _userId = userId;


            var weightValuesPounds = new List<int>();
            for (var i = 50; i <= 400; i++) weightValuesPounds.Add(i);

            var heightValuesFeet = new List<int>();
            for (var i = 2; i <= 9; i++) heightValuesFeet.Add(i);

            var heightValuesInch = new List<int>();
            for (var i = 0; i <= 11; i++) heightValuesInch.Add(i);


            GoalWeight.ItemsSource = weightValuesPounds;
            CurrentWeight.ItemsSource = weightValuesPounds;


            HeightFeet.ItemsSource = heightValuesFeet;
            HeightInch.ItemsSource = heightValuesInch;
        }

        private async void UpdateGoals_Clicked(object sender, EventArgs e)
        {
            var userAppInfoDb = LoadUserAppInfoDatabase();

            var height = int.Parse(HeightFeet.SelectedItem.ToString()) * 12 +
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
            var fileName = "Database.db3";
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var dbPath = Path.Combine(folderPath, fileName);

            return new DatabaseManager<UserAppInfo>(dbPath);
        }
    }
}