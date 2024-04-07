using System;
using SeniorProjectHealthApplication.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views.Food
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddFoodPage : ContentPage
    {
        public AddFoodPage(string categoryID)
        {
            InitializeComponent();
            BindingContext = new AddFoodPageViewModel(categoryID);

            // Set the CategoryID property when the page is created
            CategoryID = categoryID;

            // Display CategoryID on the MealPage, for instance in a Label
            Lbl_CatagoryId.Text = CategoryID;
        }

        public string CategoryID { get; }


        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void Barcode_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BarcodePage(CategoryID));
        }
    }
}