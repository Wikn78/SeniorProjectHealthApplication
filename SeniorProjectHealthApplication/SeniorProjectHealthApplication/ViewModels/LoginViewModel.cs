using SeniorProjectHealthApplication.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SeniorProjectHealthApplication.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command ForgotPassword { get; }
        public Command CreateAccount { get; }
        private string username;
        public string Username
        {
            get => username;
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            ForgotPassword = new Command(OnForgotPassword);
            CreateAccount = new Command(OnCreateAccount);
        }

        private async void OnLoginClicked(object obj)
        {
            // Access username and password here: this.Username, this.Password
            // Rest of your login logic
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            Console.WriteLine(Password + Username);
        }
        
        private async void OnCreateAccount(object obj)
        {
            //Functionality Here
            await Shell.Current.GoToAsync($"//{nameof(CreateAccountPage)}");
            await new NavigationPage(new CreateAccountPage());
        }
        
        private async void OnForgotPassword(object obj)
        {
            //Functionality Here
            Console.WriteLine("Frogot password =e-=r=w=-2=-231=-4-21=3-21=-4-=213-=4");
        }
        
    }

}
