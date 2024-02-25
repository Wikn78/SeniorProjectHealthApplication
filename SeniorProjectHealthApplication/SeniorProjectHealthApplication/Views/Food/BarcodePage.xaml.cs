using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views.Food
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarcodePage : ContentPage
    {
        private readonly string _categoryId;

        public BarcodePage(string categoryId)
        {
            InitializeComponent();
            _categoryId = categoryId;
        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddFoodPage(_categoryId));
        }
    }
}