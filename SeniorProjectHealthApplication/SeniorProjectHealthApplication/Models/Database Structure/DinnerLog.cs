using System;
using System.Collections.Generic;
using System.Text;

namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class DinnerLog
    {
        public int Id { get; set; }
        public int FL_ID { get; set; }
        public string Food_Name { get; set; }
        public float Quantity { get; set; }
    }
}
