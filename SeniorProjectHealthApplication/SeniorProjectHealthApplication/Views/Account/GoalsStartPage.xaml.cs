using System;
using System.Collections.Generic;
using SeniorProjectHealthApplication.Models;
using SeniorProjectHealthApplication.Models.Database_Structure;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoalsStartPage : ContentPage
    {
        private readonly Dictionary<int, double> _activityLevelMet = new Dictionary<int, double>()
        {
            { 0, 1.2 },
            { 1, 1.375 },
            { 2, 1.55 },
            { 3, 1.725 },
            { 4, 1.9 }
        };

        private readonly Dictionary<int, double> _baseIntakeGoal = new Dictionary<int, double>()
        {
            { 0, -500 }, // weight loss
            { 1, 0 }, // maintain weight
            { 2, 500 } // gain weight
        };

        private readonly double _currentWeight;
        private readonly double _targetWeight;
        private double _activityLevel;
        private double _intakeGoal;
        private double _newValue;
        private double _recommendedCaloricIntake;
        private double previousTotal = 100;
        private double total = 100;

        public GoalsStartPage(string currentWeight, string targetWeight)
        {
            InitializeComponent();

            _currentWeight = double.Parse(currentWeight);
            _targetWeight = double.Parse(targetWeight);
            proteinSlider.Value = 30;
            carbsSlider.Value = 20;
            fatsSlider.Value = 50;
            UpdateLabels();
        }

        private void WeightGoalIndexChange(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                _intakeGoal = _baseIntakeGoal[selectedIndex];
                UpdateCalorieIntake(_newValue);
            }
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            double stepValue = 0.1;
            var newStep = Math.Round(e.NewValue / stepValue);
            var newValue = newStep * stepValue;

            ((Slider)sender).Value = newValue;
            _newValue = newValue;

            var weeklyLossRate = newValue;
            var timeToGoalWeight = CalculateTimeToGoalWeight(_currentWeight, _targetWeight, weeklyLossRate);

            // Updating UI
            Lbl_lbPerWeek.Text = $"{newValue:f1} lb / week";
            Lbl_weeksToLoose.Text = DateTime.Today.AddDays(timeToGoalWeight).ToString("d");

            UpdateCalorieIntake(_newValue);
        }

        private double CalculateTimeToGoalWeight(double currentWeight, double targetWeight, double lossRate)
        {
            var totalWeightToLose = currentWeight - targetWeight;
            var totalCaloriesToLose = totalWeightToLose * 3500;
            var dailyCalorieDeficit = lossRate * 3500 / 7;

            // Ensuring no division by zero
            return Math.Abs(dailyCalorieDeficit) < 1e-6 ? 0 : totalCaloriesToLose / dailyCalorieDeficit;
        }

        private async void UpdateCalorieIntake(double lossPerWeek)
        {
            var totalCaloriesBurnedPerDay = await UserDataManager.OnGetUserBmr(false) * _activityLevel;

            // Calculate weight adjustment based on whether we're losing or gaining weight
            double weightAdjustment = 500 * lossPerWeek;
            if (_intakeGoal < 0) // If the goal is to lose weight, we subtract the weight adjustment
                weightAdjustment *= -1;
            else if (_intakeGoal == 0)
                weightAdjustment *= 0;

            double adjustedIntakeGoal = _intakeGoal + weightAdjustment;
            _recommendedCaloricIntake = totalCaloriesBurnedPerDay + adjustedIntakeGoal;

            // Updating UI
            UpdateLabels();
            Lbl_TotalEat.Text = $"{_recommendedCaloricIntake:f0} estimated intake";
        }

        private void WorkoutLevelIndexChange(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                _activityLevel = _activityLevelMet[selectedIndex];
                UpdateCalorieIntake(_newValue);
            }
        }

    
        private bool isSliderValueChangedProgrammatically = false;

        private void OnMacroSliderChange(object sender, ValueChangedEventArgs e)
        {
            // If the event was triggered by code, just ignore it
            if (isSliderValueChangedProgrammatically)
            {
                return;
            }

            var slider = (Slider)sender;
            var newTotal = proteinSlider.Value + carbsSlider.Value + fatsSlider.Value;
            var change = newTotal - previousTotal;

            // Set this flag to true as we're about to change slider values programmatically
            isSliderValueChangedProgrammatically = true;

            if (slider == proteinSlider)
            {
                AdjustOtherSlidersEvenly(carbsSlider, fatsSlider, -change);
            }
            else if (slider == carbsSlider)
            {
                AdjustOtherSlidersEvenly(proteinSlider, fatsSlider, -change);
            }
            else if (slider == fatsSlider)
            {
                AdjustOtherSlidersEvenly(proteinSlider, carbsSlider, -change);
            }

            // Reset the flag to false after we are done with programmatically changing slider values
            isSliderValueChangedProgrammatically = false;

            previousTotal = proteinSlider.Value + carbsSlider.Value + fatsSlider.Value;
            UpdateLabels();
        }

        private void AdjustOtherSlidersEvenly(Slider slider1, Slider slider2, double totalAdjustment)
        {
            double adjustment1 = totalAdjustment / 2;
            double adjustment2 = totalAdjustment - adjustment1; // Incorporate potential rounding errors

            AdjustSliderValue(slider1, adjustment1);
            AdjustSliderValue(slider2, adjustment2);
        }

        private void AdjustSliderValue(Slider slider, double adjustment)
        {
            slider.Value += adjustment;
            if (slider.Value < 0) slider.Value = 0;
            if (slider.Value > 100) slider.Value = 100;
        }

        private double _proteinGram, _carbGram, _fatGram;

        private void UpdateLabels()
        {
            // Calculate and update your respective percentages here:
            _proteinGram = (_recommendedCaloricIntake / 4) * (proteinSlider.Value / 100.0f) ;
            _carbGram = (_recommendedCaloricIntake / 4) * (carbsSlider.Value / 100.0f);
            _fatGram = (_recommendedCaloricIntake / 9) * (fatsSlider.Value / 100.0f);
            
            
            proteinLabel.Text = $"{_proteinGram:f0}G ({proteinSlider.Value:f1}%)";
            carbsLabel.Text = $"{_carbGram:f0}G ({carbsSlider.Value:f1}%)";
            fatsLabel.Text = $"{_fatGram:f0}G ({fatsSlider.Value:f1}%)";
        }

        private async void SaveGoalsClicked(object sender, EventArgs e)
        {
            var userNutritionDb = await UserDataManager.LoadDatabase<UserNutrition>();
            userNutritionDb.AddItem(new UserNutrition
            {
                Uid =  Preferences.Get("userId", 0),
                CaloricIntake = (float)_recommendedCaloricIntake,
                Date = DateTime.Today.ToString("d"),
                ProteinIntake = (float)_proteinGram,
                FatIntake = (float)_fatGram,
                CarbIntake = (float)_carbGram,
                WeightPerWeek = _newValue.ToString("f1")
                
            });
            
            await Navigation.PushAsync(new DashboardPage());

        }
    }
}