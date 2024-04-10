using System;
using SeniorProjectHealthApplication.ViewModels;
using SeniorProjectHealthApplication.Views.Food;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views.Page_Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddedFoodItem : ContentView
    {
        public static readonly BindableProperty Food_NameProperty =
            BindableProperty.Create(nameof(Food_Name), typeof(string), typeof(AddedFoodItem));

        public static readonly BindableProperty Total_CaloriesProperty =
            BindableProperty.Create(nameof(Total_Calories), typeof(int),
                typeof(AddedFoodItem)); // Assuming Calories is int

        public static readonly BindableProperty QuantityProperty =
            BindableProperty.Create(nameof(Quantity), typeof(float), typeof(AddedFoodItem)); // Assuming Quantity is int


        public static readonly BindableProperty CatagoryIDProperty =
            BindableProperty.Create(nameof(CatagoryID), typeof(string),
                typeof(AddedFoodItem)); // Assuming Quantity is int

        private Models.Database_Structure.FoodItem foodItem;

        public AddedFoodItem()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public string Food_Name
        {
            get => (string)GetValue(Food_NameProperty);
            set => SetValue(Food_NameProperty, value);
        }

        public int Total_Calories
        {
            get => (int)GetValue(Total_CaloriesProperty);
            set => SetValue(Total_CaloriesProperty, value);
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

        private void ViewFoodItem_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ViewFoodItemPage(Food_Name, Quantity, Total_Calories, CatagoryID, "", false));
        }


        private void RemoveButtonClicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as FoodCategoryViewModel;
            viewModel?.RemoveFoodItem(foodItem);
        }
    }
}