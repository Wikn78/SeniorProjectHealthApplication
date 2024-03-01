using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        private readonly int _userId;

        public DashboardPage()
        {
            InitializeComponent();

            var userId = Xamarin.Essentials.Preferences.Get("userId", 0);

            _userId = userId;


            LoadFoodUserData();
        }

        private async void LoadFoodUserData()
        {
            // check if a current date has a food log, if not make one.
        }


        private async void Account_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}