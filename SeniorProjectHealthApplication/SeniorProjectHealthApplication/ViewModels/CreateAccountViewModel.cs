using System;
using SeniorProjectHealthApplication.Views;
using Xamarin.Forms;

namespace SeniorProjectHealthApplication.ViewModels
{
    public class CreateAccountViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;

        public CreateAccountViewModel(INavigation navigation)
        {
            _navigation = navigation;
            CreateAccount = new Command(OnCreateAccount);
        }

        public Command GoBack { get; }
        public Command CreateAccount { get; }


        private async void OnCreateAccount(object obj)
        {
            // Access username and password here: this.Username, this.Password
            // Rest of your login logic
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            // show error of program not having them being null.
            if (_firstName == "") return;
            if (_lastName == "") return;
            if (_email == "") return;


            if (_confirmedPassword == _password)
            {
                Console.WriteLine("Account Created");
                await _navigation.PushAsync(new WelcomePage());
            }
            else
            {
                Console.WriteLine("Passwords dont match");
            }
        }

        #region Create Account Variables

        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _lastName;

        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _email;

        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
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
                    OnPropertyChanged();
                }
            }
        }

        private string _confirmedPassword;

        public string ConfirmedPassword
        {
            get => _confirmedPassword;
            set
            {
                if (_confirmedPassword != value)
                {
                    _confirmedPassword = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion
    }
}