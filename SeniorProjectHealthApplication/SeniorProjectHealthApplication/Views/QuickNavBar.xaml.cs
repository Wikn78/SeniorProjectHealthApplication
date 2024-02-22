using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuickNavBar : ContentView
    {
        public QuickNavBar()
        {
            InitializeComponent();
        }
        
        private async void Log_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DashboardPage());
        }
        private async void Progress_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private void QuickAdd_Tapped(object sender, EventArgs e)
        {
            // Handle quick add tap
        }

        private void Workouts_Tapped(object sender, EventArgs e)
        {
            // Handle workouts tap
        }

        private void Recipes_Tapped(object sender, EventArgs e)
        {
            // Handle recipes tap
        }
        
        public enum ActivePage
        {
            Logs,
            Progress,
            QuickAdd,
            Workouts,
            Recipes
        }

        public static readonly BindableProperty CurrentPageProperty = BindableProperty.Create(
            nameof(CurrentPage),
            typeof(ActivePage),
            typeof(QuickNavBar), 
            ActivePage.Logs, 
            propertyChanged: OnCurrentPageChanged);

        public ActivePage CurrentPage
        {
            get { return (ActivePage)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        private static void OnCurrentPageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (QuickNavBar) bindable;
    
            // Call OnPropertyChanged to notify the view that colors have changed
            control.OnPropertyChanged(nameof(LogButtonColor));
            control.OnPropertyChanged(nameof(ProgressButtonColor));
            control.OnPropertyChanged(nameof(QuickAddButtonColor));
            control.OnPropertyChanged(nameof(WorkoutsButtonColor));
            control.OnPropertyChanged(nameof(RecipesButtonColor));
        }
        
        // Add these properties to QuickNavBar.xaml.cs
        public Color LogButtonColor
        {
            get
            {
                return CurrentPage == ActivePage.Logs ? Color.Green : Color.FromHex("#80130B"); 
            }
        }

        public Color ProgressButtonColor
        {
            get
            {
                return CurrentPage == ActivePage.Progress ? Color.Green : Color.FromHex("#80130B"); 
            }
        }

        public Color QuickAddButtonColor
        {
            get
            {
                return CurrentPage == ActivePage.QuickAdd ? Color.Green : Color.FromHex("#80130B"); 
            }
        }

        public Color WorkoutsButtonColor
        {
            get
            {
                return CurrentPage == ActivePage.Workouts ? Color.Green : Color.FromHex("#80130B"); 
            }
        }

        public Color RecipesButtonColor
        {
            get
            {
                return CurrentPage == ActivePage.Recipes ? Color.Green : Color.FromHex("#80130B"); 
            }
        }
        
    }
}