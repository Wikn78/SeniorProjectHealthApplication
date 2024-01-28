using System;
using SQLite;

namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int UID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
    }
}