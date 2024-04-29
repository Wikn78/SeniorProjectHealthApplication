using Microcharts;
using SeniorProjectHealthApplication.Models;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SkiaSharp;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressPage : ContentPage
    {
        private int _userId;

        public ProgressPage()
        {
            InitializeComponent();

            var entries1 = new[]
            {
                new ChartEntry(200)
                {
                    Color = SKColor.Parse("#266489"),
                    Label = "January",
                    ValueLabel = "200"
                },
                new ChartEntry(400)
                {
                    Color = SKColor.Parse("#68B9C0"),
                    Label = "February",
                    ValueLabel = "400"
                },
                new ChartEntry(-100)
                {
                    Color = SKColor.Parse("#90D585"),
                    Label = "March",
                    ValueLabel = "-100"
                }
            };

            var entries2 = new[]
            {
                new ChartEntry(300)
                {
                    Color = SKColor.Parse("#FF1493"),
                    Label = "April",
                    ValueLabel = "300"
                },
                new ChartEntry(500)
                {
                    Color = SKColor.Parse("#8A2BE2"),
                    Label = "May",
                    ValueLabel = "500"
                },
                new ChartEntry(-150)
                {
                    Color = SKColor.Parse("#FF4500"),
                    Label = "June",
                    ValueLabel = "-150"
                }
            };


            //ChartView2.Chart = new LineChart { Entries = entries2 };

            UpdateCharts();
        }

        private async void UpdateCharts()
        {
            var userId = Preferences.Get("userId", 0);
            _userId = userId;

            var userAppInfoDb = await UserDataManager.LoadDatabase<UserAppInfo>();
            var userAppInfo = userAppInfoDb.GetUserAppInfoAll(_userId);

            ChartEntry[] weightEntry = new ChartEntry[userAppInfo.Count];

            for (int i = 0; i < userAppInfo.Count; i++)
            {
                weightEntry[i] = new ChartEntry(userAppInfo[i].Weight)
                {
                    Color = SKColor.Parse("#266489"),
                    Label = userAppInfo[i].Date,
                    ValueLabel = userAppInfo[i].Weight.ToString()
                };
            }


            ChartView1.Chart = new LineChart { Entries = weightEntry };
        }
    }
}