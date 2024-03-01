using System.Collections.Generic;
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

        public void UpdateItem(T item)
        {
            _db.Update(item);
        }
    }
}