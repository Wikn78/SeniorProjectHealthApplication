using System;
using System.IO;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeniorProjectHealthApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountSettingsPage : ContentPage
    {
        private int _userId;

        public AccountSettingsPage()
        {
            InitializeComponent();


            var userId = Xamarin.Essentials.Preferences.Get("userId", 0);

            _userId = userId;


            LoadUserSettings(_userId);
        }

        private void LoadUserSettings(int userId)
        {
            DatabaseManager<Users> userDb = LoadUserDatabase();
            var user = userDb.GetItem(userId);


            FNameLabel.Text = char.ToUpper(user.First_Name[0]) + user.First_Name.Substring(1).ToLower();
            LNameLabel.Text = char.ToUpper(user.Last_Name[0]) + user.Last_Name.Substring(1).ToLower();
            GenderLabel.Text = user.Gender;
            EmailLabel.Text = user.Email;
            BirthdateLabel.Text = user.Birthdate;


            // Input Label
            FirstNameInput.Text = user.First_Name;
            LastNameInput.Text = user.Last_Name;
            EmailInput.Text = user.Email;
            GenderInput.SelectedItem = user.Gender;

            if (DateTime.TryParse(user.Birthdate, out var bDay))
            {
                BirthdateInput.Date = bDay;
            }
        }

        private DatabaseManager<Users> LoadUserDatabase()
        {
            string fileName = "Database.db3";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(folderPath, fileName);

            return new DatabaseManager<Users>(dbPath);
        }

        private void UpdateSettings_Clicked(object sender, EventArgs e)
        {
            DatabaseManager<Users> userDb = LoadUserDatabase();
            var user = userDb.GetItem(_userId);

            if (user.First_Name != FirstNameInput.Text)
            {
                user.First_Name = FirstNameInput.Text.ToLower();
            }

            if (user.Last_Name != LastNameInput.Text)
            {
                user.Last_Name = LastNameInput.Text.ToLower();
            }

            if (user.Email != EmailInput.Text)
            {
                user.Email = EmailInput.Text.ToLower();
            }

            if (user.Birthdate != BirthdateInput.Date.ToShortDateString())
            {
                user.Birthdate = BirthdateInput.Date.ToShortDateString();
            }

            if (user.Gender != (string)GenderInput.SelectedItem)
            {
                user.Gender = (string)GenderInput.SelectedItem;
            }


            userDb.UpdateItem(user);

            LoadUserSettings(_userId);
        }
    }
}