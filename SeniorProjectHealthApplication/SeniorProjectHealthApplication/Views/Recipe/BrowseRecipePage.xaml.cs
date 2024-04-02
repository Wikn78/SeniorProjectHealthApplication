using SeniorProjectHealthApplication.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrowseRecipePage : ContentPage
    {
        public int ID;
        public BrowseRecipePage(int RecipeID)
        {
            InitializeComponent();
            this.BindingContext = new RecipesViewModel(RecipeID);
        }

        private RecipesViewModel ViewModel => BindingContext as RecipesViewModel;
    }
}