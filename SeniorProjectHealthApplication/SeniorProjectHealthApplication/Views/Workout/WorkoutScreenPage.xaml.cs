using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutScreenPage : ContentPage
    {
        public WorkoutScreenPage()
        {
            InitializeComponent();
        }

        private async void Superman_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkoutVideoPage());
        }
    }
}