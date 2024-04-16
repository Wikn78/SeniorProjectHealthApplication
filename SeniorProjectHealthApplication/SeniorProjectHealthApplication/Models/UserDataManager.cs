using System;
using System.IO;
using System.Threading.Tasks;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using Xamarin.Essentials;

namespace SeniorProjectHealthApplication.Models
{
    public static class UserDataManager
    {
        public static async Task<float> OnGetUserBmr(bool isMetric)
        {
            var userId = Preferences.Get("userId", 0);

            var userInfoDb = await LoadDatabase<UserAppInfo>();
            var usersDb = await LoadDatabase<Users>();
            var userInfo = userInfoDb.GetUserAppInfo(userId);
            var user = usersDb.GetItem(userId);

            var bmr = 0.0f;

            var weight = userInfo.Weight;
            var height = userInfo.Height;
            var age = GetAge(user.Birthdate);

            if (!isMetric)
            {
                weight *= 0.45359237f;
                height *= 2.54f;
            }

            if ("Female" == user.Gender) return 447.593f + 9.247f * weight + 3.098f * height - 4.330f * age;

            return 88.362f + 13.397f * weight + 4.799f * height - 5.677f * age;


            int GetAge(string userBirthdate)
            {
                var birthdate = DateTime.Parse(user.Birthdate);
                var userAge = DateTime.Today.Year - birthdate.Year;
                if (birthdate.Date > DateTime.Today.AddYears(-userAge)) userAge--;

                return userAge;
            }
        }

        public static Task<DatabaseManager<T>> LoadDatabase<T>() where T : new()
        {
            var fileName = "Database.db3";
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var dbPath = Path.Combine(folderPath, fileName);

            return Task.FromResult(new DatabaseManager<T>(dbPath));
        }
    }
}