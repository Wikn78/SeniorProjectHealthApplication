using SeniorProjectHealthApplication.Services;
using SeniorProjectHealthApplication.Views;
using SeniorProjectHealthApplication.Views.Account;
using Xamarin.Forms;

namespace SeniorProjectHealthApplication
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new GoalsStartPage("270", "210"));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}