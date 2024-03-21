namespace SeniorProjectHealthApplication.Models
{
    public static class UserDataManager
    {
        public static float OnGetUserBmr(string gender, float height, float weight, int age, bool isMetric)
        {
            float bmr = 0.0f;

            if (!isMetric)
            {
                weight *= 0.45359237f;
                height *= 2.54f;
            }

            if ("Female" == gender)
            {
                return 447.593f + (9.247f * weight) + (3.098f * height) - (4.330f * age);
            }

            return 88.362f + (13.397f * weight) + (4.799f * height) - (5.677f * age);
        }
    }
}