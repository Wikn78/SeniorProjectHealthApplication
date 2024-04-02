using System;
using SeniorProjectHealthApplication.Views.Food;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views.Page_Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodItem : ContentView
    {
        public static readonly BindableProperty FoodNameProperty =
            BindableProperty.Create(nameof(FoodName), typeof(string), typeof(AddedFoodItem));

        public static readonly BindableProperty CaloriesProperty =
            BindableProperty.Create(nameof(Calories), typeof(int), typeof(AddedFoodItem)); // Assuming Calories is int

        public static readonly BindableProperty QuantityProperty =
            BindableProperty.Create(nameof(Quantity), typeof(float), typeof(AddedFoodItem)); // Assuming Quantity is int


        public static readonly BindableProperty CatagoryIDProperty =
            BindableProperty.Create(nameof(CatagoryID), typeof(string),
                typeof(AddedFoodItem)); // Assuming Quantity is int


        public FoodItem()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public string FoodName
        {
            get => (string)GetValue(FoodNameProperty);
            set => SetValue(FoodNameProperty, value);
        }

        public int Calories
        {
            get => (int)GetValue(CaloriesProperty);
            set => SetValue(CaloriesProperty, value);
        }

        public float Quantity
        {
            get => (float)GetValue(QuantityProperty);
            set => SetValue(QuantityProperty, value);
        }

        public string CatagoryID
        {
            get => (string)GetValue(CatagoryIDProperty);
            set => SetValue(CatagoryIDProperty, value);
        }


        private void ViewFoodItem_Tapped(object sender, EventArgs args)
        {
            Navigation.PushAsync(new ViewFoodItemPage(FoodName, Quantity, 10,CatagoryID, true));
        }
    }
}