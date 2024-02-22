using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutVideo : ContentPage
    {
        public WorkoutVideo()
        {
            InitializeComponent();


            WebView webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = "https://drive.google.com/file/d/1kUFRV7h7_NcEv2sfdGsUb8nK-TlhxoKx/view?usp=drive_link"
                },
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Content = new StackLayout
            {
                Children = { webView
            }
            };
        }
    }
}

        
