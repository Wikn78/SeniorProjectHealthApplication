using System;
using System.Collections.Generic;
using System.Text;

namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class DinnerLog
    {
        public int id { get; set; }
        public int FL_ID { get; set; }
        public string food_name { get; set; }
        public float quantity { get; set; }
    }
}
