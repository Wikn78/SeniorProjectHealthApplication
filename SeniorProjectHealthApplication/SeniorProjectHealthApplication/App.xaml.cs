using System;
using System.IO;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using SeniorProjectHealthApplication.Services;
using SeniorProjectHealthApplication.Views;
using Xamarin.Forms;

namespace SeniorProjectHealthApplication
{
    public partial class App : Application
    {
        private readonly DatabaseManager<ExerciseDatabase> _dbExerciseDatabase;
        public App()
        {
            InitializeComponent();
            _dbExerciseDatabase = LoadDatabase<ExerciseDatabase>();
  
            ExerciseDatabaseExist();
            
            // check if excersie database exist
            // if it does skip
            // if not call method to make it


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
        private bool ExerciseDatabaseExist()
        {


            return false;
        }
        private void GenerateExerciseDatabase()
        {
            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            { //Id=0
                Exercise_Link = "https://drive.google.com/file/d/1aAMkQec_AxJ1elgcf2Rop7oAklVacX3d/view?usp=drive_link",
                Exercise_Name = "Plank Jacks"
            });


            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            { //Id=1
                Exercise_Link = "https://drive.google.com/file/d/17M9Ham9e-W0DaBq7DmY3L0DtdWHtOFb9/view?usp=drive_link",
                Exercise_Name = "Standing Oblique Crunches"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            { //Id=2
                Exercise_Link = "https://drive.google.com/file/d/1QHNx9e2Vn5K08YBlTfQIZOQYA39xgOdQ/view?usp=drive_link",
                Exercise_Name = "Burpee"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            { //Id=3
                Exercise_Link = "https://drive.google.com/file/d/1aq3fsTFro0hSjERZsZCK6w8pmJ4By3SO/view?usp=drive_link",
                Exercise_Name = "Donkey Kicks"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            { //Id=4
                Exercise_Link = "https://drive.google.com/file/d/1ZvmHYAVjNuCjnpiT_CpEuivEdHZoN7IW/view?usp=drive_link",
                Exercise_Name = "Reverse Lunges"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            { //Id=5
                Exercise_Link = "https://drive.google.com/file/d/1PAE6ANLWVHCJiayT_HVHF0YgBN6Y8PYa/view?usp=drive_link",
                Exercise_Name = "Abdominal Crunch"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            { //Id=6
                Exercise_Link = "https://drive.google.com/file/d/1kUFRV7h7_NcEv2sfdGsUb8nK-TlhxoKx/view?usp=drive_link",
                Exercise_Name = "Superman"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            { //Id=7
                Exercise_Link = "https://drive.google.com/file/d/1haj5CKHawx793CwvOjw10p-9ZexNqrdS/view?usp=drive_link",
                Exercise_Name = "Extended Leg Pulses"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            { //Id=8
                Exercise_Link = "https://drive.google.com/file/d/1e7hvDDJs6cVJu4K5AfCWfnz6G190ywUj/view?usp=drive_link",
                Exercise_Name = "Side Lunges"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            { //Id=9
                Exercise_Link = "https://drive.google.com/file/d/13b1XcuscMVc3eN_iF_C7ML6guCpEgZq7/view?usp=drive_link",
                Exercise_Name = "Lunge"
            });

       


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