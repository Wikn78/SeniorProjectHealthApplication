using SQLite;

namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int UID { get; set; }
        public string Username { get; set; }
        
    }
}