using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    public delegate void CategoryClickedEventHandler(object sender, EventArgs e);

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardCategory : ContentView
    {
        public event CategoryClickedEventHandler CategoryClicked;

        public static readonly BindableProperty CategoryNameProperty = BindableProperty.Create(nameof(CategoryName), typeof(string), typeof(DashboardCategory), default(string), propertyChanged: OnCategoryNameChanged);
        public static readonly BindableProperty ImagePathProperty = BindableProperty.Create(nameof(ImagePath), typeof(string), typeof(DashboardCategory), default(string), propertyChanged: OnImagePathChanged);
        public static readonly BindableProperty CategoryIDProperty = BindableProperty.Create(nameof(CategoryID), typeof(string), typeof(DashboardCategory), default(string));

        public string CategoryName
        {
            get { return (string)GetValue(CategoryNameProperty); }
            set { SetValue(CategoryNameProperty, value); }
        }
    
        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        public string CategoryID
        {
            get { return (string)GetValue(CategoryIDProperty); }
            set { SetValue(CategoryIDProperty, value); }
        }

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

        public DashboardCategory()
        {
            InitializeComponent();
            CategoryClicked += OpenFoodPage;
        }
        
        public void OpenFoodPage(object sender, EventArgs e)
        {
            // Your code
            Console.WriteLine(CategoryID + " was clicked");
        }

        // Method to invoke the event
        private void OnTapGestureTapped(object sender, EventArgs e) 
        {
            // Invoke your custom event here
            CategoryClicked?.Invoke(this, EventArgs.Empty);
        }
        
    }
}