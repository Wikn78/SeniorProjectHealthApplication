using System;
using Newtonsoft.Json;
using OpenFoodFactsCSharp.Models;
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


        public static readonly BindableProperty CatagoryIDProperty =
            BindableProperty.Create(nameof(CategoryID), typeof(string),
                typeof(AddedFoodItem)); // Assuming Quantity is int

        public static readonly BindableProperty ProductInformationProperty =
            BindableProperty.Create(nameof(ProductInformation), typeof(string),
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

        public string CategoryID
        {
            get => (string)GetValue(CatagoryIDProperty);
            set => SetValue(CatagoryIDProperty, value);
        }

        public string ProductInformation
        {
            get => (string)GetValue(ProductInformationProperty);
            set => SetValue(ProductInformationProperty, value);
        }

        private void ViewFoodItem_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ViewFoodItemPage(CategoryID, ProductInformation, false));
        }


        private async void RemoveButtonClicked(object sender, EventArgs e)
        {
            Product product = JsonConvert.DeserializeObject<Product>(ProductInformation);
            // add primary key as a what ever so it works and i dont need to wreite a gay custom thing
            var foodDb = await UserDataManager.LoadDatabase<Models.Database_Structure.FoodItem>();

            Console.WriteLine("jajajaja");
        }
    }
}