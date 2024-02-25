using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutScreen : ContentPage
    {
        public WorkoutScreen()
        {
            InitializeComponent();
        }

        private async void Superman_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkoutVideo());
        }
    }
}