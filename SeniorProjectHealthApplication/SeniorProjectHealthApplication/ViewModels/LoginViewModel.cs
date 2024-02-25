using System;
using SeniorProjectHealthApplication.Views;
using Xamarin.Forms;

namespace SeniorProjectHealthApplication.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;

        private string _password;

        private string _username;

        public LoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Register = new Command(ExecuteRegister);
            Login = new Command(ExecuteLogin);
            RecoverPassword = new Command(ExecuteRecoverPassword);
        }

        // Commands for user actions
        public Command Login { get; }
        public Command RecoverPassword { get; }
        public Command Register { get; }

        // Public property for user's username
        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }

        // Public property for user's password
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
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
            await _navigation.PushAsync(new ForgotPasswordPage());
        }
    }
}