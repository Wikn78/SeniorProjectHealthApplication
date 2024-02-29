using System.Collections.Generic;
using SQLite;

namespace SeniorProjectHealthApplication.Models.DB_Repositorys
{
    public class DatabaseManager<T> where T : new()
    {
        SQLiteConnection db;


        public DatabaseManager(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<T>();
        }

        public void AddItem(T item)
        {
            db.Insert(item);
        }

        public List<T> GetAllItems()
        {
            return db.Table<T>().ToList();
        }

        public T GetItem(int id)
        {
            return db.Get<T>(id);
        }
    }
}