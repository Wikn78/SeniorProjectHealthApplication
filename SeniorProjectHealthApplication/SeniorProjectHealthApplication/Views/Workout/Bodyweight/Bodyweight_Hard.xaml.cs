﻿using System;
using SeniorProjectHealthApplication.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views.Workout.Bodyweight
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bodyweight_Hard : ContentPage
    {
        public Bodyweight_Hard()
        {
            InitializeComponent();
            BindingContext = new OpenWorkoutViewModel();
        }

        private void Main_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}