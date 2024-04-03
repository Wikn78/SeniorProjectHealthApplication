using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views.Food
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewFoodItemPage : ContentPage
    {
        private readonly bool _addItem;

        public ViewFoodItemPage(string itemName, float quanity, float unitCal, string catagoryId, bool addItem)
        {
            InitializeComponent();

            FoodName = itemName;
            Quantiy = quanity;
            CatagoryId = catagoryId;
            
            Lbl_CatagoryId.Text = itemName;

            _addItem = addItem;

            if (!_addItem) Button_ItemUpdate.Text = "Update Item";
        }

        public string FoodName { get; set; }
        public string CatagoryId { get; set; }
        public float Quantiy { get; set; }

        private void Track_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FoodCatagoryPage(Xamarin.Essentials.Preferences.Get("categoryId", "breakfast")));
        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            if (_addItem)
                Navigation.PushAsync(new AddFoodPage(Xamarin.Essentials.Preferences.Get("categoryId", "breakfast")));
            else
                Navigation.PushAsync(new FoodCatagoryPage(Xamarin.Essentials.Preferences.Get("categoryId", "breakfast")));
        }
    }
}