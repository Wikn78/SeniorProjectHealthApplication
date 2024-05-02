﻿using System;
using System.Collections.Generic;
using System.IO;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using SeniorProjectHealthApplication.Views.Account;
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


            await Navigation.PushAsync(new GoalsStartPage(CurrentWeight.SelectedItem.ToString(),
                GoalWeight.SelectedItem.ToString()));
        }


        private DatabaseManager<UserAppInfo> LoadUserAppInfoDatabase()
        {
            var fileName = "Database.db3";
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var dbPath = Path.Combine(folderPath, fileName);

            return new DatabaseManager<UserAppInfo>(dbPath);
        }


        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = "https://drive.google.com/file/d/1I3urWoXcyO1c3PA_8giSROMMkcsq5wHz/view?usp=sharing"
                },
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var contentPage = new ContentPage { Content = webView };

            // Add a 'Back' Button to close the WebView
            contentPage.ToolbarItems.Add(new ToolbarItem
            {
                Text = "Back",
                Command = new Command(async () => await Application.Current.MainPage.Navigation.PopModalAsync())
            });

            // Open WebView as a Modal
            await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(contentPage));
        }
    }
}