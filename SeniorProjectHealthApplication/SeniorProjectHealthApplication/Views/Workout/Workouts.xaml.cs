using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Workouts : ContentPage
    {
        // Commands


        public Workouts()
        {
            InitializeComponent();
        }


        private async void BodyWeight_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkoutScreen());
        }
    }
}