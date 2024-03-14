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

            // Add a Recipe for testing
            recipesListDB.AddItem(new RecipesList
            {
                ReceipeName = "Smoothie Bowl",
                RecipePicture = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fimages.themodernproper.com%2Fbillowy-turkey%2Fproduction%2Fposts%2F2021%2FSmoothie-Bowl-8.jpeg%3Fw%3D1200%26h%3D1800%26q%3D82%26fm%3Djpg%26fit%3Dcrop%26dm%3D1641225383%26s%3D58ecd9e484aacbe2ccf896b18ce81779&tbnid=lvr0Mzv2m9jD5M&vet=12ahUKEwjp8JbDy_SEAxX91MkDHXbfBhQQMygAegUIARDwAQ..i&imgrefurl=https%3A%2F%2Fthemodernproper.com%2Fhow-to-make-a-smoothie-bowl&docid=VHmhc1pkTDriVM&w=1200&h=1800&q=smoothie%20bowl&ved=2ahUKEwjp8JbDy_SEAxX91MkDHXbfBhQQMygAegUIARDwAQ",
                Calories = 214,
                Carbs = 47.5,
                Protein = 2.8,
                Fat = 2.5,
                SaturatedFat = 1.6,
                Sodium = 9,
                Sugar = 25.9,
                Ingredients = "Smoothie Bowl\n1 cup organic frozen mixed berries\n1 small ripe banana (sliced and frozen)\n2-3 Tbsp light coconut or almond milk\nToppings\n1 Tbsp shredded unsweetened coconut\n1 Tbsp chia seeds\n1 Tbsp hemp seeds\nGranola\nFruit",
                Instructions = "N/A"
            });

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
