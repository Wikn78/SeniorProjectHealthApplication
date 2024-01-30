using System;
using Xamarin.Forms;

namespace SeniorProjectHealthApplication.ViewModels
{
    public class CreateAccountViewModel : BaseViewModel
    {
        public Command GoBack { get; }
        public Command CreateAccount { get; }

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
                        OnPropertyChanged(nameof(FirstName));
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
                        OnPropertyChanged(nameof(LastName));
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
                        OnPropertyChanged(nameof(Email));
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
            
            private string _confirmedPassword;
            public string ConfirmedPassword
            {
                get => _confirmedPassword;
                set
                {
                    if (_confirmedPassword != value)
                    {
                        _confirmedPassword = value;
                        OnPropertyChanged(nameof(ConfirmedPassword));
                    }
                }
            }
            
            

        #endregion

        public CreateAccountViewModel()
        {

            CreateAccount = new Command(OnCreateAccount);
        }
        
        
        
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
                
            }
            else
            {
                Console.WriteLine("Passwords dont match");
            }
            
        }
        
        
        
        
    }
}