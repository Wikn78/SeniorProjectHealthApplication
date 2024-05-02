using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuickNavBar : ContentView
    {
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

        public QuickNavBar()
        {
            InitializeComponent();
        }

        public ActivePage CurrentPage
        {
            get => (ActivePage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        // Add these properties to QuickNavBar.xaml.cs
        public Color LogButtonColor => CurrentPage == ActivePage.Logs ? Color.Green : Color.FromHex("#80130B");

        public Color ProgressButtonColor => CurrentPage == ActivePage.Progress ? Color.Green : Color.FromHex("#80130B");

        public Color QuickAddButtonColor => CurrentPage == ActivePage.QuickAdd ? Color.Green : Color.FromHex("#80130B");

        public Color WorkoutsButtonColor => CurrentPage == ActivePage.Workouts ? Color.Green : Color.FromHex("#80130B");

        public Color RecipesButtonColor => CurrentPage == ActivePage.Recipes ? Color.Green : Color.FromHex("#80130B");

        private async void Log_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DashboardPage());
        }

        private async void Progress_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProgressPage());
        }


        private async void QuickAdd_Tapped(object sender, EventArgs e)
        {
            // Overlay.IsVisible = !Overlay.IsVisible;
        }

        private async void Workouts_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkoutsPage());
        }

        private async void Recipes_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecipesPage());
        }

        private static void OnCurrentPageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (QuickNavBar)bindable;

            // Call OnPropertyChanged to notify the view that colors have changed
            control.OnPropertyChanged(nameof(LogButtonColor));
            control.OnPropertyChanged(nameof(ProgressButtonColor));
            control.OnPropertyChanged(nameof(QuickAddButtonColor));
            control.OnPropertyChanged(nameof(WorkoutsButtonColor));
            control.OnPropertyChanged(nameof(RecipesButtonColor));
        }

        private void OnOverlayTapped(object sender, EventArgs e)
        {
        }
    }
}