using System;
using System.ComponentModel;
using Newtonsoft.Json;
using OpenFoodFactsCSharp.Models;
using SeniorProjectHealthApplication.Models;
using SeniorProjectHealthApplication.Models.Database_Structure;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views.Food
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewFoodItemPage : ContentPage, INotifyPropertyChanged
    {
        private readonly bool _addItem;
        private Product _product;
        private float _quantity;

        private string _totalCalories, _totalProtein, _totalCarbs, _totalFat;

        public ViewFoodItemPage(string itemName, float quanity, float unitCal, string catagoryId, string productInfo,
            bool addItem)
        {
            InitializeComponent();

            // Use barcode to set the values of it

            _product = JsonConvert.DeserializeObject<Product>(productInfo);

            FoodName = _product.ProductName;
            Quantity = 1;
            CatagoryId = catagoryId;

            Lbl_CatagoryId.Text = FoodName;

            UpdateNutrition();
            _addItem = addItem;

            if (!_addItem) Button_ItemUpdate.Text = "Update Item";
        }

        public float Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }


        public string FoodName { get; set; }
        public string CatagoryId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void UpdateNutrition()
        {
            _totalCalories = (_product.Nutriments.EnergyKcalServing * Quantity)?.ToString("f0");
            _totalProtein = (_product.Nutriments.ProteinsServing * Quantity)?.ToString("f0");
            _totalCarbs = (_product.Nutriments.CarbohydratesServing * Quantity)?.ToString("f0");
            _totalFat = (_product.Nutriments.CarbohydratesServing * Quantity)?.ToString("f0");

            UpdateNutritionLabels();
        }

        private void UpdateNutritionLabels()
        {
            Lbl_FoodCalories.Text = _totalCalories;
            Lbl_Protein.Text = _totalProtein;
            Lbl_Carbs.Text = _totalCarbs;
            Lbl_Fat.Text = _totalFat;
        }


        private async void Track_Clicked(object sender, EventArgs e)
        {
            var foodDb = await UserDataManager.LoadDatabase<FoodItem>();


            if (_addItem)
            {
                // add new item
                foodDb.AddItem(new FoodItem
                {
                    Food_Name = _product.ProductName,
                    Barcode_ID = "",
                    FL_ID = 1,
                    Unit_Calorie = float.Parse(_totalCalories) / Quantity,
                    Total_Calories = float.Parse(_totalCalories),
                    Quantity = Quantity,
                    FoodCategory = int.Parse(Preferences.Get("currentCategory", "")),
                    ProductInformation = JsonConvert.SerializeObject(_product)
                });
            }
            else
            {
                // update the food in the database of this one
            }


            await Navigation.PushAsync(new FoodCatagoryPage(Preferences.Get("categoryId", "breakfast")));
        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void OnQuantityTextChanged(object sender, TextChangedEventArgs e)
        {
            float newQuantity;
            if (float.TryParse(e.NewTextValue, out newQuantity))
            {
                Quantity = newQuantity;

                UpdateNutrition();
            }
            else
            {
                // handle invalid input
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}