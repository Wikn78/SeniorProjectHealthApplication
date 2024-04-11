using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutScreenPage : ContentPage
    {
        private readonly DatabaseManager<ExerciseDatabase> _dbExerciseDatabase;

        public WorkoutScreenPage()
        {
            InitializeComponent();
            _dbExerciseDatabase = LoadDatabase<ExerciseDatabase>();
        }

        private async void Workout_Clicked(int workout_id, object sender, EventArgs e)
        {

            var webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                 

                    Url = _dbExerciseDatabase.GetItem(10).Exercise_Link
                   
                },
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Content = new StackLayout
            {
                Children =
                {
                    webView
                }
            };
        }

        private DatabaseManager<T> LoadDatabase<T>() where T : new()
        {
            string fileName = "ExerciseDatabase.db3";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(folderPath, fileName);



            return new DatabaseManager<T>(dbPath);
        }

    }
}