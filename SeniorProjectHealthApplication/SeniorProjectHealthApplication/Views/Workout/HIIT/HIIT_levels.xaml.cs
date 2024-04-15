using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views.Workout.HIIT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HIIT_levels : ContentPage
    {
        public HIIT_levels()
        {
            InitializeComponent();
        }

        private async void Easy_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HIIT.HIIT_easy());
        }

        private async void Intermediate_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HIIT.HIIT_intermediate());
        }

        private async void Hard_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HIIT.HIIT_hard());
        }

        private async void Main_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}