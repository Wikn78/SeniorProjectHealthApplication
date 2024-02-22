using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class MealPage : ContentPage
   {
       public string CategoryID { get; private set; }
   
       public MealPage(string categoryID)
       {
           InitializeComponent();
   
           // Set the CategoryID property when the page is created
           CategoryID = categoryID;
   
           // Display CategoryID on the MealPage, for instance in a Label
           var categoryLabel = new Label { Text = CategoryID };
           this.Content = categoryLabel; // replace 'this.Content' with the location where you want to place the Label
       }
   }
}