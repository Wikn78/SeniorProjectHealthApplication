using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using Newtonsoft.Json;
using OpenFoodFactsCSharp.Models;
using SeniorProjectHealthApplication.Models;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using SeniorProjectHealthApplication.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using FoodItem = SeniorProjectHealthApplication.Models.Database_Structure.FoodItem;

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
            AddRecipeItemCommand = new Command(AddRecipeItem);
            // Load your recipes
            AddRecipeItems();


            // Assign to your ObservableCollection
            RecipesList = new ObservableCollection<RecipesList>(recipesListDB.GetAllItems());
        }

        public RecipesViewModel(INavigation navigation, int ID)
        {
            // Load your databases

            _navigation = navigation;
            recipesListDB = LoadDatabase<RecipesList>();
            AddRecipeItemCommand = new Command(AddRecipeItem);

            // Load your recipes
            var recipes = recipesListDB.GetRecipesListByID(ID);

            // Assign to your ObservableCollection
            RecipesList = new ObservableCollection<RecipesList>(recipes);
        }

        public ICommand AddRecipeItemCommand { get; set; }

        public ObservableCollection<RecipesList> RecipesList { get; set; }

        private async void AddRecipeItems()
        {
            var recipesListDB = await UserDataManager.LoadDatabase<RecipesList>();
            var recipes = recipesListDB.GetRecipesList();

            if (recipes.Count == 0)
            {
                // Add a food item for testing
                recipesListDB.AddItem(new RecipesList
                {
                    ReceipeName = "Frittata",
                    RecipePicture =
                        "https://www.wellplated.com/wp-content/uploads/2020/12/Healthy-Egg-White-Frittata-Recipe-500x500.jpg",
                    Calories = 273,
                    Carbs = 6,
                    Protein = 15,
                    Fat = 21,
                    SaturatedFat = 9,
                    Sodium = 404,
                    Fiber = 1,
                    Sugar = 2,
                    Ingredients =
                        "8 large eggs\r\n3/4 c. shredded mozzarella \r\n1/3 c. heavy cream\r\nKosher salt\r\nFreshly ground black pepper\r\nPinch of red pepper flakes\r\n2 tbsp. extra-virgin olive oil\r\n1 shallot, finely chopped\r\n3 cloves garlic, finely chopped\r\n8 oz. baby bella mushrooms, sliced\r\n3 c. baby spinach\r\n1/2 c. ricotta",
                    Instructions =
                        "Step 1\r\nPreheat oven to 375°. In a medium bowl, whisk eggs, mozzarella, and cream; season with salt, black pepper, and red pepper.\r\nStep 2\r\nIn a large ovenproof skillet over medium heat, heat oil. Add shallot and garlic and cook, stirring occasionally, until shallot is translucent, about 5 minutes. Add mushrooms and cook, stirring occasionally, until softened, about 5 minutes more. Add spinach and cook, stirring frequently, until wilted, about 2 minutes; season with salt and black pepper.\r\nStep 3\r\nPour egg mixture into pan over vegetables. Dollop with ricotta.\r\nStep 4\r\nBake frittata until eggs are just set and edges are golden brown, about 12 minutes."
                });

                recipesListDB.AddItem(new RecipesList
                {
                    ReceipeName = "Chocolate Chip Pancakes",
                    RecipePicture =
                        "https://lilluna.com/wp-content/uploads/2022/05/chocolate-chip-pancakes-final-resize-10-500x500.jpg",
                    Calories = 735,
                    Carbs = 95,
                    Protein = 13,
                    Fat = 35,
                    SaturatedFat = 20,
                    Sodium = 539,
                    Fiber = 4,
                    Sugar = 47,
                    Ingredients =
                        "6 tbsp. unsalted butter, softened, plus more for cooking and serving  \r\n2 large eggs, room temperature\r\n1 c. whole milk \r\n2 c. (240 g.) all-purpose flour\r\n2 tbsp. plus 2 tsp. granulated sugar \r\n1 1/4 tsp. baking powder \r\n3/4 tsp. kosher salt\r\n1 c. (170 g.) 60% bittersweet chocolate chips \r\nPure maple syrup, for serving",
                    Instructions =
                        "Step 1\r\nIn a small pot over medium heat, melt 6 tablespoons butter. You can also melt butter in a microwave safe bowl. Let cool slightly. Add eggs and milk and whisk until smooth.\r\nStep 2\r\nIn a medium bowl, whisk flour, sugar, baking powder, and salt until combined. Pour egg mixture into dry ingredients and whisk just until batter is smooth with a few lumps remaining. Let sit 5 to 10 minutes.\r\nStep 3\r\nPreheat a large skillet (preferably nonstick) or griddle over medium-low heat. Working in batches, melt some butter, swirling to coat pan, then add a heaping 1/4 cup batter per pancake (you should be able to fit 2 to 3). Sprinkle some chips on batter. Cook pancakes until tiny bubbles appear on the surface, about 2 minutes. Turn and continue to cook until golden brown and edges are firm, 1 to 2 minutes more.\r\nStep 4\r\nTransfer pancakes to a platter. Serve with butter and maple syrup alongside."
                });

                recipesListDB.AddItem(new RecipesList
                {
                    ReceipeName = "Biscuits And Gravy",
                    RecipePicture =
                        "https://simplyhomecooked.com/wp-content/uploads/2022/05/biscuits-and-gravy-recipe-21-500x500.jpg",
                    Calories = 771,
                    Carbs = 73,
                    Protein = 23,
                    Fat = 43,
                    SaturatedFat = 21,
                    Sodium = 1111,
                    Fiber = 2,
                    Sugar = 13,
                    Ingredients =
                        "BISCUITS\r\n2 1/2 c. (300 g.) all-purpose flour\r\n2 tbsp. baking powder\r\n1 tbsp. granulated sugar\r\n1 tsp. kosher salt\r\n1/2 c. (1 stick) very cold unsalted butter, plus more, melted, for brushing\r\n1 c. cold buttermilk\r\nGRAVY\r\n1/2 lb. breakfast sausage, casings removed\r\n2 tbsp. all-purpose flour\r\n2 c. whole milk\r\n1/2 tsp. (or more) kosher salt\r\nPinch of cayenne pepper\r\nFreshly ground black pepper",
                    Instructions =
                        "Step 1\r\nPreheat oven to 425º. In a large bowl, whisk flour, baking powder, granulated sugar, and salt until combined.\r\nStep 2\r\nUsing the large holes of a box grater, grate cold butter over flour mixture and quickly toss with your hands to incorporate.\r\nStep 3\r\nUsing a wooden spoon, make a well in the center and pour in buttermilk. Stir until just beginning to come together, then turn out onto a work surface. Form dough into a rectangle about 1\" thick. Starting with short end, fold dough into thirds, like folding a letter. Using a rolling pin, gently pat back to a 1\"-thick rectangle. Repeat folding process once more, working fast so butter doesn't melt.\r\nStep 4\r\nPat dough back to a 1\"-thick rectangle. Using a sharp knife, cut into 8 pieces. Transfer to a large parchment-lined baking sheet, spacing about 1/2\" apart. Brush tops of biscuits with melted butter.\r\nStep 5\r\nBake biscuits until flaky and tops are lightly golden, 20 to 22 minutes.\r\nGRAVY\r\nStep 1\r\nIn a medium skillet over medium heat, cook sausage, breaking up into small pieces with a wooden spoon, until no longer pink, about 8 minutes.\r\nStep 2\r\nSprinkle with flour and cook, stirring, until fragrant, about 1 minute. While whisking, slowly pour in milk. Bring mixture to a boil, then reduce heat to medium-low and simmer, stirring often, until thickened, 5 to 7 minutes.\r\nStep 3\r\nStir in salt and cayenne, then season with lots of black pepper; season with more salt, if needed.\r\nStep 4\r\nBreak open biscuits. Spoon gravy over."
                });

                recipesListDB.AddItem(new RecipesList
                {
                    ReceipeName = "Stuffed Peppers",
                    RecipePicture =
                        "https://www.wellplated.com/wp-content/uploads/2020/10/Best-Instant-Pot-Stuffed-Peppers-with-meat-500x500.jpg",
                    Calories = 419,
                    Carbs = 21,
                    Protein = 21,
                    Fat = 26,
                    SaturatedFat = 10,
                    Sodium = 767,
                    Fiber = 5,
                    Sugar = 8,
                    Ingredients =
                        "1/2 c. uncooked white or brown rice\r\n2 tbsp. extra-virgin olive oil, plus more for drizzling\r\n1 medium yellow onion, chopped\r\n3 cloves garlic, finely chopped\r\n2 tbsp. tomato paste\r\n1 lb. ground beef\r\n1 (14.5-oz.) can diced tomatoes\r\n1 1/2 tsp. dried oregano\r\nKosher salt\r\nFreshly ground black pepper\r\n6 bell peppers, tops and cores removed\r\n1 c. shredded Monterey jack\r\nChopped fresh parsley, for serving",
                    Instructions =
                        "Step 1\r\nPreheat oven to 400°. In a small saucepan, prepare rice according to package instructions.\r\nStep 2\r\nMeanwhile, in a large skillet over medium heat, heat oil. Cook onion, stirring occasionally, until softened, about 7 minutes. Stir in garlic and tomato paste and cook, stirring, until fragrant, about 1 minute more. Add ground beef and cook, breaking up meat with a wooden spoon, until no longer pink, about 6 minutes. Drain excess fat.\r\nStep 3\r\nStir in rice and diced tomatoes; season with oregano, salt, and pepper. Let simmer, stirring occasionally, until liquid has reduced slightly, about 5 minutes.\r\nStep 4\r\nArrange peppers cut side up in a 13\"x9\" baking dish and drizzle with oil. Spoon beef mixture into each pepper. Top with cheese, then cover baking dish with foil.\r\nStep 5\r\nBake peppers until tender, about 35 minutes. Uncover and continue to bake until cheese is bubbly, about 10 minutes more.\r\nStep 6\r\nTop with parsley before serving."
                });

                recipesListDB.AddItem(new RecipesList
                {
                    ReceipeName = "Flatbread Pizza",
                    RecipePicture = "https://ourbalancedbowl.com/wp-content/uploads/2022/08/IMG_7337-500x500.jpg",
                    Calories = 803,
                    Carbs = 72,
                    Protein = 34,
                    Fat = 41,
                    SaturatedFat = 15,
                    Sodium = 983,
                    Fiber = 5,
                    Sugar = 8,
                    Ingredients =
                        "FOR FLATBREAD\r\n2 c. all-purpose flour, plus more for surface\r\n2 tsp. baking powder\r\n1 tsp. kosher salt\r\n1/2 tsp. baking soda\r\n1 c. plain Greek yogurt\r\n2 tbsp. olive oil\r\nVegetable oil, for pan\r\nFOR TOPPING\r\n12 oz. grape tomatoes, halved\r\n1/4 small red onion, sliced\r\n2 tsp. extra-virgin olive oil\r\n2 tsp. freshly chopped oregano\r\nKosher salt\r\nFreshly ground black pepper\r\n8 oz. mozzarella, sliced into 1/4\" thick rounds\r\nBalsamic glaze, for serving\r\n2 c. arugula\r\n",
                    Instructions =
                        "Step 1\r\nPreheat oven to 400°. In a large bowl, whisk to combine flour, baking powder, salt, and baking soda. Add yogurt and oil and mix until no dry spots remain.\r\nStep 2\r\nLightly flour a clean work surface. Transfer dough to surface and knead until smooth, 3 to 4 minutes, adding more flour if the dough is sticky. \r\nStep 3\r\nDivide dough into 3 pieces, then roll each piece into 1/4\" thick round. Heat a large skillet or griddle over medium-high heat and add enough vegetable oil to coat the bottom of the pan. Cook flatbreads until golden on both sides, about 2 minutes per side. Continue cooking flatbreads, adding more vegetable oil as needed.\r\nStep 4\r\nIn a medium bowl, combine tomatoes, red onion, oil, and oregano and season with salt and pepper. Top each flatbread with cheese, tomato-onion mixture and bake until cheese is melty, 15 minutes. Drizzle with balsamic glaze and top with arugula before serving."
                });

                recipesListDB.AddItem(new RecipesList
                {
                    ReceipeName = "Barbeque Chicken Salad",
                    RecipePicture =
                        "https://inquiringchef.com/wp-content/uploads/2020/01/BBQ-Chicken-Salad_square-2974-500x500.jpg",
                    Calories = 484,
                    Carbs = 35,
                    Protein = 33,
                    Fat = 20,
                    SaturatedFat = 6,
                    Sodium = 882,
                    Fiber = 8,
                    Sugar = 16,
                    Ingredients =
                        "2 boneless, skinless chicken breasts (about 1 lb. total)\r\nKosher salt\r\nFreshly ground black pepper\r\n3/4 c. store-bought BBQ sauce, divided\r\n1/3 c. buttermilk\r\n1/4 c. mayonnaise\r\n1/4 c. sour cream\r\n1 clove garlic, finely chopped\r\n2 tbsp. chopped fresh parsley\r\n1 tbsp. chopped fresh dill\r\n1 tbsp. sliced fresh chives\r\n1/4 tsp. onion powder\r\nPinch of cayenne pepper\r\n2 heads romaine lettuce, thinly sliced (about 8 c.)\r\n1 (15-oz.) can black beans, rinsed, drained\r\n1 vine-ripened tomato, finely chopped (about 1 c.)\r\n1 c. shredded Mexican blend cheese\r\n1 c. frozen corn, thawed, drained\r\n1 c. tortilla strips or crushed tortilla chips\r\n1/4 c. finely chopped red onion",
                    Instructions =
                        "Step 1\r\nPlace chicken between 2 pieces of plastic wrap and pound with a meat mallet into 1/2\"-thick pieces. Transfer chicken to a large bowl; season all over with 1 teaspoon salt and 1/4 teaspoon black pepper. Pour 1/2 cup BBQ sauce over chicken. Turn to coat and let marinate, tossing a few times, at least 15 minutes at room temperature, or cover bowl and refrigerate up to 3 hours. \r\nStep 2\r\nMeanwhile, prepare a grill for medium-high heat; heat 5 minutes (or preheat a grill pan over medium-high heat). In a medium bowl, whisk buttermilk, mayonnaise, sour cream, garlic, parsley, dill, chives, onion powder, cayenne, 3/4 teaspoon salt, and 1/4 teaspoon black pepper; set dressing aside.\r\nStep 3\r\nGrill chicken, basting with marinade, until cooked through, about 5 minutes per side. Transfer to a cutting board and let cool slightly. Cut chicken into bite-sized pieces.\r\nStep 4\r\nIn a large bowl, toss chicken, lettuce, beans, tomatoes, cheese, corn, tortilla strips, and onion. Drizzle with some of the reserved dressing and remaining 1/4 cup BBQ sauce and toss again to combine. Serve remaining dressing alongside."
                });

                recipesListDB.AddItem(new RecipesList
                {
                    ReceipeName = "Mac And Cheese",
                    RecipePicture =
                        "https://www.saltandlavender.com/wp-content/uploads/2021/11/stovetop-mac-and-cheese-recipe-1-500x500.jpg",
                    Calories = 900,
                    Carbs = 61,
                    Protein = 42,
                    Fat = 53,
                    SaturatedFat = 28,
                    Sodium = 880,
                    Fiber = 3,
                    Sugar = 10,
                    Ingredients =
                        "1/2 c. (1 stick) unsalted butter, plus more for baking dish\r\nKosher salt\r\n1 lb. elbow macaroni\r\n1/2 c. all-purpose flour\r\n5 c. whole milk\r\n1 tsp. mustard powder\r\nFreshly ground black pepper\r\n12 oz. shredded cheddar (about 3 c.)\r\n8 oz. shredded Gruyère (about 2 c.)\r\n3 oz. finely grated Parmesan (about 1 1/2 c.), divided\r\n1 c. panko bread crumbs\r\n3 tbsp. extra-virgin olive oil",
                    Instructions =
                        "Step 1\r\nPreheat oven to 375°. Grease a 13\"x9\" baking dish with butter. In a large pot of boiling salted water, cook macaroni, stirring occasionally, until al dente, 5 to 6 minutes. Drain.\r\nStep 2\r\nIn a large saucepan over medium heat, melt 1 stick butter. Sprinkle flour over and cook, stirring, until slightly golden, 2 to 3 minutes. Pour in milk and whisk until combined. Add mustard powder; season with salt and pepper. Bring to a simmer over medium-high heat and cook, stirring, until sauce starts to thicken, about 2 minutes.\r\nStep 3\r\nRemove pan from heat and whisk in cheddar, Gruyère, and 1 cup Parmesan until melted and smooth. Stir in macaroni and transfer to prepared dish.\r\nStep 4\r\nIn a small bowl, combine panko, oil, and remaining 1/2 cup Parmesan. Sprinkle over macaroni; season with more pepper.\r\nStep 5\r\nBake mac and cheese until bubbly and golden, 25 to 30 minutes. Let cool 10 minutes."
                });

                recipesListDB.AddItem(new RecipesList
                {
                    ReceipeName = "Chicken Stir-Fry",
                    RecipePicture =
                        "https://natashaskitchen.com/wp-content/uploads/2018/08/Chicken-Stir-Fry-1-1-500x500.jpg",
                    Calories = 366,
                    Carbs = 22,
                    Protein = 35,
                    Fat = 15,
                    SaturatedFat = 2,
                    Sodium = 1252,
                    Fiber = 6,
                    Sugar = 13,
                    Ingredients =
                        "1/2 c. reduced-sodium soy sauce\r\n2 tbsp. honey\r\n2 tsp. toasted sesame oil\r\n1 tbsp. canola oil\r\n1 head broccoli, cut into small florets\r\n1 bell pepper, seeds and ribs removed, chopped\r\n2 cloves garlic, finely chopped\r\n1 lb. boneless, skinless chicken breast, cut into 1\" pieces\r\n1/3 c. cashews\r\nFreshly ground black pepper",
                    Instructions =
                        "Step 1\r\nIn a small bowl, whisk soy sauce, honey, and sesame oil. \r\nStep 2\r\nIn a large skillet over high heat, heat oil. Cook broccoli, bell pepper, and garlic, stirring frequently, until softened, about 5 minutes. Add chicken and cook, tossing occasionally, until golden brown and cooked through, about 8 minutes. Stir in cashews; season with pepper.\r\nStep 3\r\nPour sauce into skillet and bring to a simmer. Cook, stirring occasionally, until thickened, about 5 minutes."
                });

                recipesListDB.AddItem(new RecipesList
                {
                    ReceipeName = "Pad Thai",
                    RecipePicture =
                        "https://www.recipetineats.com/wp-content/uploads/2020/01/Chicken-Pad-Thai_9-SQ.jpg?w=500&h=500&crop=1",
                    Calories = 658,
                    Carbs = 59,
                    Protein = 36,
                    Fat = 30,
                    SaturatedFat = 3,
                    Sodium = 1362,
                    Fiber = 3,
                    Sugar = 11,
                    Ingredients =
                        "8 oz. rice noodles, broken in half\r\n6 tbsp. peanut or vegetable oil, divided\r\n1 lb. medium shrimp, peeled, deveined, tails removed\r\n3 large eggs\r\n3 tbsp. palm sugar\r\n3 tbsp. Thai fish sauce\r\n2 tbsp. tamarind puree\r\n1 tbsp. fresh lime juice, plus lime wedges for serving\r\n1/4 tsp. cayenne pepper\r\n1 medium shallot, finely chopped (about 3 tbsp.)\r\n3 cloves garlic, finely chopped\r\n6 scallions, cut into 1\" pieces\r\n1 c. bean sprouts\r\n1/4 c. coarsely chopped peanuts\r\n2 tbsp. coarsely chopped fresh cilantro (optional) ",
                    Instructions =
                        "Step 1\r\nIf using dried noodles, in a large pot or heatproof bowl, soak noodles in boiling water until tender, 20 to 30 minutes.\r\nStep 2\r\nMeanwhile, in a large wok over high heat, heat 1 tablespoon oil. Add shrimp and cook, turning halfway through, until just cooked through and pink, 2 to 3 minutes. Transfer to a medium bowl.\r\nStep 3\r\nIn same wok, heat 1 tablespoon oil. In a small bowl, whisk eggs until blended. Cook, stirring occasionally and breaking up curds with a spoon, until just set, 1 to 2 minutes. Transfer to bowl with shrimp.\r\nStep 4\r\nIn a small bowl, whisk palm sugar, fish sauce, tamarind concentrate, lime juice, cayenne, 2 tablespoons oil, and 1 tablespoon water until combined.\r\nStep 5\r\nIn same wok over medium-high heat, heat 2 tablespoons oil. Cook shallot and garlic, stirring frequently, until lightly golden, about 1 minute. Add scallions and cook, stirring frequently, until softened, 1 to 2 minutes. Stir in sauce and bring to a simmer.\r\nStep 6\r\nAdd eggs, shrimp, and noodles and cook, tossing constantly, until warmed through and noodles are softened, about 2 minutes more. Add bean sprouts and peanuts and toss again to combine. \r\nStep 7\r\nDivide pad Thai among plates. Top with cilantro (if using)."
                });
            }
        }


        private async void AddRecipeItem()
        {
            var foodDb = await UserDataManager.LoadDatabase<FoodItem>();
            var product = new Product
            {
                Nutriments = new Nutriments
                {
                    CarbohydratesServing = (float?)RecipesList[0].Carbs,
                    ProteinsServing = (float?)RecipesList[0].Protein,
                    FatServing = (float?)RecipesList[0].Fat,
                    EnergyKcalServing = (float?)RecipesList[0].Calories
                },
                ProductName = RecipesList[0].ReceipeName
            };

            foodDb.AddItem(new FoodItem
            {
                Food_Name = product.ProductName,
                Barcode_ID = "0000000",
                FL_ID = Preferences.Get("currentFoodCategory_Id", 0),
                Unit_Calorie = (float)product.Nutriments.EnergyKcalServing,
                Total_Calories = (float)product.Nutriments.EnergyKcalServing,
                Quantity = 1,
                FoodCategory = GetFoodCatagory(MySelectedItem),
                ProductInformation = JsonConvert.SerializeObject(product)
            });

            await _navigation.PushAsync(new DashboardPage());

            int GetFoodCatagory(string mySelectedItem)
            {
                switch (mySelectedItem.ToLower())
                {
                    case "breakfast":
                        return 1;
                    case "lunch":
                        return 2;
                    case "dinner":
                        return 3;
                    case "snack":
                        return 4;
                    default:
                        return 1;
                }
            }
        }

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

        private string _mySelectedItem;

        public string MySelectedItem
        {
            get => _mySelectedItem;
            set
            {
                if (_mySelectedItem != value)
                {
                    _mySelectedItem = value;
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