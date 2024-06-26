﻿using System;
using SeniorProjectHealthApplication.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views.Workout.HIIT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HIIT_easy : ContentPage
    {
        public HIIT_easy()
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