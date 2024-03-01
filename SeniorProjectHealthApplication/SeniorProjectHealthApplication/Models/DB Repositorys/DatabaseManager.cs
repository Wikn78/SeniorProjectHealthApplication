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


        public UserAppInfo GetUserAppInfo(int uid)
        {
            return _db.Table<UserAppInfo>()
                .Where(item => item.UID == uid)
                .OrderByDescending(item => item.Date)
                .FirstOrDefault();
        }

        public FoodLog GetFoodLogInfoByDate(string dateTime)
        {
            return _db.Table<FoodLog>()
                .Where(item => item.Date == dateTime)
                .OrderByDescending(item => item.Date)
                .FirstOrDefault();
        }

        public BreakfastLog GetBreakfastLogInfoByFLID(int fl_id)
        {
            return _db
                .Table<BreakfastLog>().FirstOrDefault(item => item.FL_ID == fl_id);
        }

        public LunchLog GetLunchLogInfoByFLID(int fl_id)
        {
            return _db
                .Table<LunchLog>().FirstOrDefault(item => item.FL_ID == fl_id);
        }

        public DinnerLog GetDinnerLogInfoByFLID(int fl_id)
        {
            return _db
                .Table<DinnerLog>().FirstOrDefault(item => item.FL_ID == fl_id);
        }

        public SnackLog GetSnackLogInfoByFLID(int fl_id)
        {
            return _db
                .Table<SnackLog>().FirstOrDefault(item => item.FL_ID == fl_id);
        }

        public void UpdateItem(T item)
        {
            _db.Update(item);
        }
    }
}