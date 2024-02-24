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
        // Commands for user actions
        public Command Login { get; }
        public Command RecoverPassword { get; }
        public Command Register { get; }

        private string _username;

        // Public property for user's username
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

        // Public property for user's password
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

        private INavigation _navigation;

        public LoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Register = new Command(ExecuteRegister);
            Login = new Command(ExecuteLogin);
            RecoverPassword = new Command(ExecuteRecoverPassword);

        }

        private async void ExecuteLogin(object obj)
            {
                //Execute login logic here
                await _navigation.PushAsync(new DashboardPage());
            }

            private async void ExecuteRegister(object obj)
            {
                // Execute account creation logic here
                try
                {
                    await _navigation.PushAsync(new CreateAccountPage());
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("Null reference exception: " + ex.Message);
                    throw;
                }
            }

            private async void ExecuteRecoverPassword(object obj)
            {
                // Execute password recovery logic here
            }
        }

    }

