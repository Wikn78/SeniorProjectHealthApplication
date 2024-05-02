using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoalsPage : ContentPage
    {
        private readonly int _userId;

        public GoalsPage()
        {
            InitializeComponent();

            var userId = Preferences.Get("userId", 0);

            _userId = userId;

            // Fill the dropd downs;
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


            UpdateValues();
        }

        private async void UpdateValues()
        {
            // fill with data
            var userInfoDB = await LoadUserAppInfoDatabase();
            var userInfo = userInfoDB.GetUserAppInfo(_userId);

            GoalWeight.SelectedItem = (int)userInfo.GoalWeight;
            CurrentWeight.SelectedItem = (int)userInfo.Weight;

            HeightFeet.SelectedItem = (int)(userInfo.Height / 12);
            HeightInch.SelectedItem = (int)(userInfo.Height % 12);
        }

        private async void UpdateGoals_Clicked(object sender, EventArgs e)
        {
            var userInfoDB = await LoadUserAppInfoDatabase();


            var height = int.Parse(HeightFeet.SelectedItem.ToString()) * 12 +
                         int.Parse(HeightInch.SelectedItem.ToString());

            userInfoDB.AddItem(new UserAppInfo
            {
                Date = DateTime.Now.ToString(),
                UID = _userId,
                Height = height,
                Weight = int.Parse(CurrentWeight.SelectedItem.ToString()),
                GoalWeight = int.Parse(GoalWeight.SelectedItem.ToString())
            });


            UpdateValues();
        }


        private Task<DatabaseManager<UserAppInfo>> LoadUserAppInfoDatabase()
        {
            var fileName = "Database.db3";
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var dbPath = Path.Combine(folderPath, fileName);

            return Task.FromResult(new DatabaseManager<UserAppInfo>(dbPath));
        }

        private void OnBackButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}