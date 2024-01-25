using System;
using System.Collections.Generic;
using System.Text;

namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class ExerciseLog
    {
        public int id { get; set; }
        public int UID { get; set; }
        public string date { get; set; }
        public string exercise { get; set; }
        public float caloriesBurned { get; set; }
    }
}
