using System;
using SeniorProjectHealthApplication.ViewModels;
using SeniorProjectHealthApplication.Views.Food;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodCatagoryPage : ContentPage
    {
        string CategoryID;

        public FoodCatagoryPage(string categoryID)
        {
            InitializeComponent();
            this.BindingContext = new FoodCategoryViewModel(categoryID);
            CategoryID = categoryID;
            // Display CategoryID on the MealPage, for instance in a Label
            Lbl_CategoryId.Text =
                System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(categoryID.ToLower());
            Lbl_FoodDate.Text = Xamarin.Essentials.Preferences.Get("selectedDate", "");
            //Lbl_TotalCalories.Text = ViewModel.TotalCalories.ToString();
        }

        private FoodCategoryViewModel ViewModel => BindingContext as FoodCategoryViewModel;

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