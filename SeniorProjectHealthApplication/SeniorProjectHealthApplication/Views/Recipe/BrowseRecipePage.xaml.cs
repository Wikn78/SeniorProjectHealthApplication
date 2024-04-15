using SeniorProjectHealthApplication.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrowseRecipePage : ContentPage
    {
        public int ID;
        public BrowseRecipePage(int RecipeID)
        {
            InitializeComponent();
            this.BindingContext = new RecipesViewModel(RecipeID);
        }

        private RecipesViewModel ViewModel => BindingContext as RecipesViewModel;

        private void Add_Recipe(object sender, EventArgs e)
        {
            Console.WriteLine("Calories: " + ViewModel.Calories + " Protein: " + ViewModel.Protein + " Carbs: " + ViewModel.Carbs  + " Fat: " + ViewModel.Fat);
        }
    }
}