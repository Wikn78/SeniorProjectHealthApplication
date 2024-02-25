using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }


        private async void Notifications_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotificationsPage());
        }

        private async void HelpAndSupport_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpAndSupport_Page());
        }

        private async void PrivacyAndSecurity_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PrivacyAndSecurity());
        }

        private async void Account_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccountSettings());
        }
    }
}