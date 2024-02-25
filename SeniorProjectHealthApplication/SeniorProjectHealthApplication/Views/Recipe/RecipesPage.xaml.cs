using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipesPage : ContentPage
    {
        public RecipesPage()
        {
            InitializeComponent();
        }

        private async void Recipe_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BrowseRecipePage());
        }
    }
}