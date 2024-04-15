using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views.Workout
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutLevels : ContentPage
    {
        public WorkoutLevels()
        {
            InitializeComponent();
        }

        private async void Easy_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Bodyweight.Bodyweight_Easy());
        }

        private async void Intermediate_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Bodyweight.Bodyweight_Intermediate());
        }

        private async void Hard_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Bodyweight.Bodyweight_Hard());
        }

        private void Main_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}