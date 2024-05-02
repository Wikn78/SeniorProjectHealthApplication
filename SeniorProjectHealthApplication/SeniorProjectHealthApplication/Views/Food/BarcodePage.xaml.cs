using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SeniorProjectHealthApplication.Models;
using SeniorProjectHealthApplication.Models.Database_Structure;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

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

        private async void CheckBarCode_Clicked(object sender, EventArgs e)
        {
            var barcodeID = BarcodeEntry.Text;
            // 01275900
            var product = await FoodDatabaseManager.GetProductByBarCodeAsync(barcodeID);
            if (product != null)
            {
                var foodItem = new FoodItem
                {
                    ProductInformation = JsonConvert.SerializeObject(product.Product), // makes into json
                    FoodCategory = Preferences.Get("foodCategory_Id", 0),
                    Barcode_ID = product.Product.Id,
                    FL_ID = Preferences.Get("currentFoodCategory_Id", 0),
                    Food_Name = product.Product.ProductName,
                    Total_Calories = (product.Product.Nutriments.EnergyKcalServing =
                        product.Product.Nutriments.EnergyKcalServing) ?? 0,
                    Quantity = 1,
                    Unit_Calorie = (product.Product.Nutriments.EnergyKcalServing =
                        product.Product.Nutriments.EnergyKcalServing) ?? 0
                };
                
                
                await Navigation.PushAsync(new ViewFoodItemPage(foodItem.Barcode_ID, foodItem.ProductInformation, true));
                
            }
           
        }
    }
}