using System;
using System.IO;
using System.Linq;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using SeniorProjectHealthApplication.Views;
using Xamarin.Forms;

namespace SeniorProjectHealthApplication.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;

        private string _email;

        private string _password;

        public LoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Register = new Command(ExecuteRegister);
            Login = new Command(ExecuteLogin);
            RecoverPassword = new Command(ExecuteRecoverPassword);

            LoadUserInfo();
        }

        private async void LoadUserInfo()
        {
            var authToken = await Xamarin.Essentials.SecureStorage.GetAsync("AuthToken");

            if (!string.IsNullOrEmpty(authToken))
            {
                var userId = int.Parse(authToken);
                if(userId > 0)
                {
                    Xamarin.Essentials.Preferences.Set("userId", userId); 
                    await _navigation.PushAsync(new DashboardPage());
                    
                }
                
                
            }
        }

        // Commands for user actions
        public Command Login { get; }
        public Command RecoverPassword { get; }
        public Command Register { get; }

        // Public property for user's username
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

            string fileName = "Database.db3";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(folderPath, fileName);
            var userRepo = new DatabaseManager<Users>(dbPath);

            var user = userRepo.GetAllItems().FirstOrDefault(u => u.Email == _email);

            if (user != null)
            {
                if (VerifyPassword(_password, user.Password))
                {
                    if (user.UID != 0)
                    {
                        Xamarin.Essentials.Preferences.Set("userId", user.UID);
                    }

                    await Xamarin.Essentials.SecureStorage.SetAsync("AuthToken", user.UID.ToString());
                    await _navigation.PushAsync(new DashboardPage());
                }
            }
        }


        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
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