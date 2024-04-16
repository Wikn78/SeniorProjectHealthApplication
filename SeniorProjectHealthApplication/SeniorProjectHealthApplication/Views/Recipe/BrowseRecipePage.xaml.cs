using System;
using Newtonsoft.Json;
using OpenFoodFactsCSharp.Models;
using SeniorProjectHealthApplication.Models;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views.Recipe
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

        private async void Add_Recipe(object sender, EventArgs e)
        {
            var foodDb = await UserDataManager.LoadDatabase<FoodItem>();
            var product = new Product
            {
                Nutriments = new Nutriments
                {
                    CarbohydratesServing = (float?)ViewModel.Carbs,
                    ProteinsServing = (float?)ViewModel.Protein,
                    FatServing = (float?)ViewModel.Fat,
                    EnergyKcalServing = (float?)ViewModel.Calories
                },
                ProductName = lbl_RecipeName.Text,
            };

            foodDb.AddItem(new FoodItem
            {
                Food_Name = product.ProductName,
                Barcode_ID = "",
                FL_ID = Preferences.Get("currentFoodCategory_Id", 0),
                Unit_Calorie = (float)ViewModel.Calories,
                Total_Calories = (float)ViewModel.Calories,
                Quantity = 1,
                FoodCategory = 2,
                ProductInformation = JsonConvert.SerializeObject(product)
            });

            Console.WriteLine("Calories: " + ViewModel.Calories + " Protein: " + ViewModel.Protein + " Carbs: " +
                              ViewModel.Carbs + " Fat: " + ViewModel.Fat);
        }
    }
}