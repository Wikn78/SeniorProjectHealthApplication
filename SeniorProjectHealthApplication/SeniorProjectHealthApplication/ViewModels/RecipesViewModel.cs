using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using SeniorProjectHealthApplication.Views;
using SeniorProjectHealthApplication.Views.Page_Views;
using Xamarin.Forms;

namespace SeniorProjectHealthApplication.ViewModels
{
    class RecipesViewModel : BaseViewModel 
    {
        private readonly INavigation _navigation;


        DatabaseManager<RecipesList> recipesListDB;


        public RecipesViewModel()
        {
            // Load your databases
            recipesListDB = LoadDatabase<RecipesList>();



            // Load your recipes
            var recipes = recipesListDB.GetRecipesList();

            // Assign to your ObservableCollection
            RecipesList = new ObservableCollection<RecipesList>(recipes);
        }

        public ObservableCollection<RecipesList> RecipesList { get; set; }
        private DatabaseManager<T> LoadDatabase<T>() where T : new()
        {
            string fileName = "Database.db3";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(folderPath, fileName);

            return new DatabaseManager<T>(dbPath);
        }
        #region Create Recipe Variables

        private string _recipeName;

        public string RecipeName
        {
            get => _recipeName;
            set
            {
                if (_recipeName != value)
                {
                    _recipeName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _recipePicture;

        public string RecipePicture
        {
            get => _recipePicture;
            set
            {
                if (_recipePicture != value)
                {
                    _recipePicture = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _calories;

        public double Calories
        {
            get => _calories;
            set
            {
                if (_calories != value)
                {
                    _calories = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _carbs;

        public double Carbs
        {
            get => _carbs;
            set
            {
                if (_carbs != value)
                {
                    _carbs = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _protein;

        public double Protein
        {
            get => _protein;
            set
            {
                if (_protein != value)
                {
                    _protein = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _fat;

        public double Fat
        {
            get => _fat;
            set
            {
                if (_fat != value)
                {
                    _fat = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _saturatedFat;

        public double SaturatedFat
        {
            get => _saturatedFat;
            set
            {
                if (_saturatedFat != value)
                {
                    _saturatedFat = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _sodium;

        public double Sodium
        {
            get => _sodium;
            set
            {
                if (_sodium != value)
                {
                    _sodium = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _fiber;

        public double Fiber
        {
            get => _fiber;
            set
            {
                if (_fiber != value)
                {
                    _fiber = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _sugar;

        public double Sugar
        {
            get => _sugar;
            set
            {
                if (_sugar != value)
                {
                    _sugar = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _ingredients;

        public string Ingredients
        {
            get => _ingredients;
            set
            {
                if (_ingredients != value)
                {
                    _ingredients = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _instructions;

        public string Instructions
        {
            get => _instructions;
            set
            {
                if (_instructions != value)
                {
                    _instructions = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
    }
}
