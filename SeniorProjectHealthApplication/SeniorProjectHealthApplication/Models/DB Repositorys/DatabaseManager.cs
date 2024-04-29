using System;
using System.Collections.Generic;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SQLite;

namespace SeniorProjectHealthApplication.Models.DB_Repositorys
{
    public class DatabaseManager<T> where T : new()
    {
        private readonly SQLiteConnection _db;

        public DatabaseManager(string dbPath)
        {
            _db = new SQLiteConnection(dbPath);
            _db.CreateTable<T>();
        }

        public void AddItem(T item)
        {
            _db.Insert(item);
        }

        public List<T> GetAllItems()
        {
            return _db.Table<T>().ToList();
        }

        public T GetItem(int id)
        {
            return _db.Get<T>(id);
        }

        public int CheckTableExists()
        {
            return _db.Table<T>().Count();
        }

        public void DeleteItem(int id)
        {
            _db.Delete<T>(id);
        }


        public UserAppInfo GetUserAppInfo(int uid)
        {
            return _db.Table<UserAppInfo>()
                .Where(item => item.UID == uid)
                .OrderByDescending(item => item.Date)
                .FirstOrDefault();
        }

        public List<UserAppInfo> GetUserAppInfoAll(int uid)
        {
            return _db.Table<UserAppInfo>()
                .Where(item => item.UID == uid)
                .OrderBy(item => item.Date).ToList();
        }

        public UserNutrition GetUserNutrition(int uid)
        {
            return _db
                .Table<UserNutrition>()
                .FirstOrDefault(item => item.Uid == uid);
        }

        public FoodLog GetFoodLogInfoByDate(string dateTime, int uid)
        {
            return _db.Table<FoodLog>()
                .Where(item => item.Date == dateTime).Where(item => item.UID == uid)
                .OrderByDescending(item => item.Date)
                .FirstOrDefault();
        }

        public FoodLogCategory GetFoodLogCategory(int fl_id, int fl_category)
        {
            return _db
                .Table<FoodLogCategory>().Where(item => item.FoodCatagory == fl_category)
                .FirstOrDefault(item => item.FL_ID == fl_id);
        }

        public List<FoodItem> GetFoodItems(int id, int fl_category)
        {
            return _db
                .Table<FoodItem>().Where(item => item.FL_ID == id).Where(item => item.FoodCategory == fl_category)
                .ToList();
        }

        public List<RecipesList> GetRecipesList()
        {
            return _db
                .Table<RecipesList>()
                .ToList();
        }

        public List<RecipesList> GetRecipesListByID(int ID)
        {
            return _db
                .Table<RecipesList>()
                .Where(x => x.Id == ID)
                .ToList();
        }

        public void UpdateItem(T item)
        {
            _db.Update(item);
        }

        public void UpdateFoodItem(FoodItem item, string name)
        {
            FoodItem foodItem = _db.Table<FoodItem>().FirstOrDefault(x => x.Food_Name == name);
            if (Math.Abs(item.Quantity - foodItem.Quantity) > .01f)
            {
                foodItem.Quantity = item.Quantity;
                foodItem.Total_Calories = item.Total_Calories;
            }

            _db.Update(foodItem);
        }
    }
}