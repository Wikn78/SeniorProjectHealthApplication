using System;
using SeniorProjectHealthApplication.ViewModels;
using SeniorProjectHealthApplication.Views.Recipe;
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
            BindingContext = new RecipesViewModel();
        }


        private RecipesViewModel ViewModel => BindingContext as RecipesViewModel;

        private async void Recipe_Tapped(object sender, EventArgs e)
        {
            int ID = (int)((Button)sender).BindingContext;
            await Navigation.PushAsync(new BrowseRecipePage(ID));
        }
    }
}