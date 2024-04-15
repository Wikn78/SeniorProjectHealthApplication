using System;
using SeniorProjectHealthApplication.Views.Workout;
using SeniorProjectHealthApplication.Views.Workout.Cardiovascular;
using SeniorProjectHealthApplication.Views.Workout.Flexbility_and_Balance;
using SeniorProjectHealthApplication.Views.Workout.HIIT;
using SeniorProjectHealthApplication.Views.Workout.Strength_Training;
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
    }
}