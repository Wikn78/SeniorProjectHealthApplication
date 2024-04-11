using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SeniorProjectHealthApplication.ViewModels
{
    public class OpenWorkoutViewModel 
    {
        public ICommand OpenWorkoutCommand { get; set; }

        public OpenWorkoutViewModel() 
        {
            OpenWorkoutCommand = new Command<string>(ExecuteOpenWorkout);  
        }

        private void ExecuteOpenWorkout(string workoutId)
        {
            int id = Int32.Parse(workoutId);


        }

    }
}
