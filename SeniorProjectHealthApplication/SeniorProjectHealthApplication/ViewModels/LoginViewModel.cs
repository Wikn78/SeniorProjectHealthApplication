using SeniorProjectHealthApplication.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
using Xamarin.Forms;  
using Xamarin.Forms.Xaml;
namespace SeniorProjectHealthApplication.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command ForgotPassword { get; }
        public Command CreateAccount { get; }
        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
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
            try
            {
               // await Navigation.PushAsync(new CreateAccountPage());
            }
            catch (NullReferenceException ex)
            {
                // Log the exception or handle it gracefully
                Console.WriteLine("Null reference exception: " + ex.Message);
                // Optionally, you can throw the exception further if needed
                throw;
            }

           //  new NavigationPage(new CreateAccountPage());
        }
        
        private async void OnForgotPassword(object obj)
        {
            //Functionality Here
            Console.WriteLine("Frogot password =e-=r=w=-2=-231=-4-21=3-21=-4-=213-=4");
        }
        
    }

}
