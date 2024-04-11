using System;
using SeniorProjectHealthApplication.Views.Food;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views.Page_Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodItem : ContentView
    {
        public static readonly BindableProperty Food_NameProperty =
            BindableProperty.Create(nameof(Food_Name), typeof(string), typeof(AddedFoodItem));

        public static readonly BindableProperty Total_CaloriesProperty =
            BindableProperty.Create(nameof(Total_Calories), typeof(int),
                typeof(AddedFoodItem)); // Assuming Calories is int

        public static readonly BindableProperty QuantityProperty =
            BindableProperty.Create(nameof(Quantity), typeof(float), typeof(AddedFoodItem)); // Assuming Quantity is int


        public static readonly BindableProperty FoodCategoryProperty =
            BindableProperty.Create(nameof(FoodCategory), typeof(string),
                typeof(AddedFoodItem)); // Assuming Quantity is int

        public static readonly BindableProperty ProductInformationProperty =
            BindableProperty.Create(nameof(ProductInformation), typeof(string),
                typeof(AddedFoodItem)); // Assuming Quantity is int


        public FoodItem()
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

        public string FoodCategory
        {
            get => (string)GetValue(FoodCategoryProperty);
            set => SetValue(FoodCategoryProperty, value);
        }

        public string ProductInformation
        {
            get => (string)GetValue(ProductInformationProperty);
            set => SetValue(ProductInformationProperty, value);
        }

        private void ViewFoodItem_Tapped(object sender, EventArgs args)
        {
            Console.WriteLine(
                $"FoodName: {FoodName_Lbl.Text}   Quantity: {Quantity_Lbl.Text}   Total_Calories: {TotalCalories_Lbl.Text}  Category ID: {FoodCategory}");
            Navigation.PushAsync(new ViewFoodItemPage(FoodCategory, ProductInformation, true));
        }
    }
}