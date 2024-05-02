using System;
using SeniorProjectHealthApplication.Models;
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


        public static readonly BindableProperty FoodCategoryProperty =
            BindableProperty.Create(nameof(FoodCategory), typeof(string),
                typeof(AddedFoodItem)); // Assuming Quantity is int

        public static readonly BindableProperty ProductInformationProperty =
            BindableProperty.Create(nameof(ProductInformation), typeof(string),
                typeof(AddedFoodItem)); // Assuming Quantity is int

        public static readonly BindableProperty FI_IDProperty =
            BindableProperty.Create(nameof(FI_ID), typeof(string),
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

        public string FI_ID
        {
            get => (string)GetValue(FI_IDProperty);
            set => SetValue(FI_IDProperty, value);
        }

        private void ViewFoodItem_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ViewFoodItemPage(FoodCategory, ProductInformation, false));
        }


        private async void RemoveButtonClicked(object sender, EventArgs e)
        {
            //Product product = JsonConvert.DeserializeObject<Product>(ProductInformation);
            // add primary key as a what ever so it works and i dont need to wreite a gay custom thing
            var foodDb = await UserDataManager.LoadDatabase<Models.Database_Structure.FoodItem>();
            foodDb.DeleteItem( Int32.Parse(FI_ID));
            await Navigation.PushAsync(new FoodCatagoryPage(FoodCategory));
        }
    }
}
