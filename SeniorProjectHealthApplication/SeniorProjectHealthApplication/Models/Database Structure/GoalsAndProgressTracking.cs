using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class GoalsAndProgressTracking
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UID { get; set; }
        public string Date { get; set; }
        public string Goal_Type { get; set; }
        public float Goal_Value { get; set; }
        public float Progress { get; set; }
    }
}
