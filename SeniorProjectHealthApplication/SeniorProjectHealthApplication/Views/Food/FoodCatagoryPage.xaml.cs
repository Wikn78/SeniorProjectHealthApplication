using System;
using SeniorProjectHealthApplication.Views.Food;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodCatagoryPage : ContentPage
    {
        public FoodCatagoryPage(string categoryID)
        {
            InitializeComponent();

            // Set the CategoryID property when the page is created
            CategoryID = categoryID;

            // Display CategoryID on the MealPage, for instance in a Label
            Lbl_CategoryId.Text = CategoryID;
        }

        public string CategoryID { get; }

        private async void AddFood_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddFoodPage(CategoryID));
        }


        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DashboardPage());
        }
    }
}