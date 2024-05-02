using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    public delegate void CategoryClickedEventHandler(object sender, EventArgs e);

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardCategory : ContentView
    {
        public static readonly BindableProperty CategoryNameProperty = BindableProperty.Create(nameof(CategoryName),
            typeof(string), typeof(DashboardCategory), propertyChanged: OnCategoryNameChanged);

        public static readonly BindableProperty ImagePathProperty = BindableProperty.Create(nameof(ImagePath),
            typeof(string), typeof(DashboardCategory), propertyChanged: OnImagePathChanged);

        public static readonly BindableProperty CategoryIDProperty =
            BindableProperty.Create(nameof(CategoryID), typeof(string), typeof(DashboardCategory));

        public DashboardCategory()
        {
            InitializeComponent();
            CategoryClicked += OpenFoodPage;
        }

        public string CategoryName
        {
            get => (string)GetValue(CategoryNameProperty);
            set => SetValue(CategoryNameProperty, value);
        }

        public string ImagePath
        {
            get => (string)GetValue(ImagePathProperty);
            set => SetValue(ImagePathProperty, value);
        }

        public string CategoryID
        {
            get => (string)GetValue(CategoryIDProperty);
            set => SetValue(CategoryIDProperty, value);
        }

        public event CategoryClickedEventHandler CategoryClicked;

        private static void OnCategoryNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (DashboardCategory)bindable;
            control.CategoryNameLabel.Text = newValue?.ToString();
        }

        private static void OnImagePathChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (DashboardCategory)bindable;
            control.CategoryImage.Source = ImageSource.FromFile(newValue?.ToString());
        }

        public void OpenFoodPage(object sender, EventArgs e)
        {
            // Your code
            Navigation.PushAsync(new FoodCatagoryPage(CategoryID));
        }

        // Method to invoke the event
        private void OnTapGestureTapped(object sender, EventArgs e)
        {
            // Invoke your custom event here
            CategoryClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}