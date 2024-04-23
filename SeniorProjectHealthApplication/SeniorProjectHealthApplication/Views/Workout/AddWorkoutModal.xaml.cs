using SeniorProjectHealthApplication.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views.Workout
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddWorkoutModal : ContentPage
    {
        public AddWorkoutModal()
        {
            InitializeComponent();
            BindingContext = new AddWorkoutModalViewModel();
        }
    }
}