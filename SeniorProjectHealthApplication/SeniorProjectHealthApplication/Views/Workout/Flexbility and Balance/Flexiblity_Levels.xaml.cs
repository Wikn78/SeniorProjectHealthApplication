using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views.Workout.Flexbility_and_Balance
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Flexiblity_Levels : ContentPage
    {
        public Flexiblity_Levels()
        {
            InitializeComponent();
        }

        private async void Easy_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Flexbility_and_Balance.Flexbility_Easy());
        }

        private async void Intermediate_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Flexbility_and_Balance.Flexiblity_Intermediate());
        }

        private async void Hard_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Flexbility_and_Balance.Flexibility_Hard());
        }
    }
}