﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeniorProjectHealthApplication.Models.Database_Structure
{
    public class ExerciseDatabase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Exercise_Name { get; set; }
        public string Difficulity { get; set; }
        public string Exercise_Explanation { get; set; }






    }
}
