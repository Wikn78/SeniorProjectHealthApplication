using SeniorProjectHealthApplication.Views.Workout;
using System;
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
    }
}