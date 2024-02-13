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

            /*var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) => CategoryClicked?.Invoke(this, new EventArgs());
            this.GestureRecognizers.Add(tapGesture);
            
            var category = new DashboardCategory { CategoryID = "<YourCategoryID>", CategoryName = "<YourCategoryName>", ImagePath = "<YourImagePath>" };
            category.CategoryClicked += async (s, e) => 
            {
                var categoryControl = s as DashboardCategory;
                var categoryID = categoryControl.CategoryID; // Here is your categoryID which was clicked
                var nextPage = new MealPage(categoryID);
                await Navigation.PushAsync(nextPage);
            };*/
        }
        
        
    }
}