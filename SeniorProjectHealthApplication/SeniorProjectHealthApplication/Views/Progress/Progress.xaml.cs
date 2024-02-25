using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Progress : ContentPage
    {
        public Progress()
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

            ChartView1.Chart = new LineChart { Entries = entries1 };
            ChartView2.Chart = new LineChart { Entries = entries2 };
        }
    }
}