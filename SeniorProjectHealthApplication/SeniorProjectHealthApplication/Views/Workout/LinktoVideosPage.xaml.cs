﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LinktoVideosPage : ContentPage
    {
        public LinktoVideosPage()
        {
            InitializeComponent();
        }

        private async void SupermanVideo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkoutVideoPage());
        }
    }
}