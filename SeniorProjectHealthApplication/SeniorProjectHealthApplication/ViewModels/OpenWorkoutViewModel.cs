using System;
using System.IO;
using System.Windows.Input;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using Xamarin.Forms;

namespace SeniorProjectHealthApplication.ViewModels
{
    public class OpenWorkoutViewModel
    {
        private readonly DatabaseManager<ExerciseDatabase> _dbExerciseDatabase;

        public OpenWorkoutViewModel()
        {
            OpenWorkoutCommand = new Command<string>(ExecuteOpenWorkout);
            _dbExerciseDatabase = LoadDatabase<ExerciseDatabase>();
        }

        public ICommand OpenWorkoutCommand { get; set; }

        private async void ExecuteOpenWorkout(string workoutId)
        {
            int id = Int32.Parse(workoutId);

            var webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = _dbExerciseDatabase.GetItem(id).Exercise_Link
                },
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var contentPage = new ContentPage { Content = webView };

            // Add a 'Back' Button to close the WebView
            contentPage.ToolbarItems.Add(new ToolbarItem
            {
                Text = "Back",
                Command = new Command(async () => await Application.Current.MainPage.Navigation.PopModalAsync())
            });

            // Open WebView as a Modal
            await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(contentPage));
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