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
        }

        private async void OnLoginClicked(object obj)
        {
            // Access username and password here: this.Username, this.Password
            // Rest of your login logic
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            Console.WriteLine(Password + Username);
        }
    }

}
