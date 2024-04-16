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
            MainPage = new NavigationPage(new LoginPage());
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