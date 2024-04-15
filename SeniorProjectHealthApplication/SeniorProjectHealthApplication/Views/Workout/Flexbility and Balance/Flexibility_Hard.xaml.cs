using System;
using SeniorProjectHealthApplication.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views.Workout.Flexbility_and_Balance
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Flexibility_Hard : ContentPage
    {
        public Flexibility_Hard()
        {
            InitializeComponent();
            BindingContext = new OpenWorkoutViewModel();
        }

        private void Main_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}