using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class RecipesList // NEEDS TO BE CHANGED LATER ON
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ReceipeName { get; set; }
    }
}
