using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeniorProjectHealthApplication.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoalsStartPage : ContentPage
    {
        private readonly double _currentWeight, _targetWeight;
        
        public GoalsStartPage(string currentWeight, string targetWeight)
        {
            InitializeComponent();

            _currentWeight = double.Parse(currentWeight);
            _targetWeight = double.Parse(targetWeight);


        }

        private double _newValue;
        private async void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            double stepValue = 0.1;
            var newStep = Math.Round(e.NewValue / stepValue);
            var newValue = newStep * stepValue;

            ((Slider)sender).Value = newValue;
            _newValue = newValue;
            Lbl_lbPerWeek.Text = newValue.ToString("f1") + " lb / week";
            double weeklyLossRate = newValue;
            // assuming currentWeight and targetWeight are defined and accessible
            double weeksToLoseWeight = CalculateTimeToLoseWeight(_currentWeight, _targetWeight, weeklyLossRate);
            // Do something with weeksToLoseWeight

            Lbl_weeksToLoose.Text = weeksToLoseWeight.ToString("f0") + " weeks";
           // calores u need to remove 
           

            UpdateCalorieIntake(_newValue);

        }
        
        public double CalculateTimeToLoseWeight(double currentWeight, double targetWeight, double lossRate)
        {
            // Calculate total weight to lose
            double totalWeightToLose = currentWeight - targetWeight;

            // Calculate total number of calories to lose that weight
            double totalCaloriesToLose = totalWeightToLose * 3500;

            // Calculate the daily calorie deficit to achieve the loss rate
            double dailyCalorieDeficit = lossRate * 3500 / 7;

            // Calculate days to lose weight
            double daysToLoseWeight = totalCaloriesToLose / dailyCalorieDeficit;

            // Convert it to weeks
            double weeksToLoseWeight = daysToLoseWeight / 7;

            return weeksToLoseWeight;
        }
        
        
        private double _activityLevel;
        private readonly Dictionary<int, double> _activityLevelMet = new Dictionary<int, double>()
        {
            { 0, 1.2 }, // MET for office job
            { 1, 1.375 }, // MET for light movement
            { 2, 1.55 }, // MET for 2/3 days of exercise
            { 3, 1.725 }, // MET for 4/5 days of exercise
            { 4, 1.9 }  // MET for 6+ days of exercise
        };
        
        private async void WorkoutLevelIndexChange(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                _activityLevel = _activityLevelMet[selectedIndex];
                UpdateCalorieIntake(_newValue);
            }
        }

        private async void UpdateCalorieIntake(double value)
        {
            // calories you need to remove 
            var dailyCalorieDeficit = value * 3500 / 7;
            var def = await UserDataManager.OnGetUserBmr(false) * _activityLevel;

            Lbl_TotalDef.Text = dailyCalorieDeficit.ToString("f0");
            Lbl_TotalBurn.Text = def.ToString("f0");

            Lbl_TotalEat.Text = (def - (float)dailyCalorieDeficit).ToString("F0");
        }

    }
}