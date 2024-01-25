using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class ExerciseLog
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UID { get; set; }
        public string Date { get; set; }
        public string Exercise { get; set; }
        public float CaloriesBurned { get; set; }
    }
}
