using SeniorProjectHealthApplication.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views.Recipe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrowseRecipePage : ContentPage
    {
        public int ID;

        public BrowseRecipePage(int RecipeID)
        {
            InitializeComponent();
            this.BindingContext = new RecipesViewModel(Navigation, RecipeID);
        }
    }
}