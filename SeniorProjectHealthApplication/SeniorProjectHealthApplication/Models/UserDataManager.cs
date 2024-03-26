using System;
using System.IO;
using System.Threading.Tasks;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;

namespace SeniorProjectHealthApplication.Models
{
    public static class UserDataManager
    {
        public static async Task<float> OnGetUserBmr(bool isMetric)
        {
            var userId = Xamarin.Essentials.Preferences.Get("userId", 0);

            DatabaseManager<UserAppInfo> userInfoDb = await LoadDatabase<UserAppInfo>();
            DatabaseManager<Users> usersDb = await LoadDatabase<Users>();
            UserAppInfo userInfo = userInfoDb.GetUserAppInfo(userId);
            Users user = usersDb.GetItem(userId);

            float bmr = 0.0f;

            float weight = userInfo.Weight;
            float height = userInfo.Height;
            int age = GetAge(user.Birthdate);

            if (!isMetric)
            {
                weight *= 0.45359237f;
                height *= 2.54f;
            }

            if ("Female" == user.Gender)
            {
                return 447.593f + (9.247f * weight) + (3.098f * height) - (4.330f * age);
            }

            return 88.362f + (13.397f * weight) + (4.799f * height) - (5.677f * age);


            int GetAge(string userBirthdate)
            {
                DateTime birthdate = DateTime.Parse(user.Birthdate);
                int userAge = DateTime.Today.Year - birthdate.Year;
                if (birthdate.Date > DateTime.Today.AddYears(-userAge)) userAge--;

                return userAge;
            }
        }

        public static Task<DatabaseManager<T>> LoadDatabase<T>() where T : new()
        {
            string fileName = "Database.db3";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(folderPath, fileName);

            return Task.FromResult(new DatabaseManager<T>(dbPath));
        }
    }
}