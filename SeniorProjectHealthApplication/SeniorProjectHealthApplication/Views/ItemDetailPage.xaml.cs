using SeniorProjectHealthApplication.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SeniorProjectHealthApplication.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}