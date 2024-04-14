using System;
using System.IO;
using SeniorProjectHealthApplication.Models.Database_Structure;
using SeniorProjectHealthApplication.Models.DB_Repositorys;
using SeniorProjectHealthApplication.Services;
using SeniorProjectHealthApplication.Views;
using Xamarin.Forms;

namespace SeniorProjectHealthApplication
{
    public partial class App : Application
    {
        private readonly DatabaseManager<ExerciseDatabase> _dbExerciseDatabase;

        public App()
        {
            InitializeComponent();
            _dbExerciseDatabase = LoadDatabase<ExerciseDatabase>();


            // if not call method to make it

            // Checks for any entries if there isnt any make the table if there is then the table is already there
            if (_dbExerciseDatabase.CheckTableExists() == 0)
            {
                GenerateExerciseDatabase();
            }

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


        private void GenerateExerciseDatabase()
        {
            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=0
                Exercise_Link = "https://drive.google.com/file/d/1aAMkQec_AxJ1elgcf2Rop7oAklVacX3d/view?usp=drive_link",
                Exercise_Name = "Plank Jacks"
            });


            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=1
                Exercise_Link = "https://drive.google.com/file/d/17M9Ham9e-W0DaBq7DmY3L0DtdWHtOFb9/view?usp=drive_link",
                Exercise_Name = "Standing Oblique Crunches"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=2
                Exercise_Link = "https://drive.google.com/file/d/1QHNx9e2Vn5K08YBlTfQIZOQYA39xgOdQ/view?usp=drive_link",
                Exercise_Name = "Burpee"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=3
                Exercise_Link = "https://drive.google.com/file/d/1aq3fsTFro0hSjERZsZCK6w8pmJ4By3SO/view?usp=drive_link",
                Exercise_Name = "Donkey Kicks"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=4
                Exercise_Link = "https://drive.google.com/file/d/1ZvmHYAVjNuCjnpiT_CpEuivEdHZoN7IW/view?usp=drive_link",
                Exercise_Name = "Reverse Lunges"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=5
                Exercise_Link = "https://drive.google.com/file/d/1PAE6ANLWVHCJiayT_HVHF0YgBN6Y8PYa/view?usp=drive_link",
                Exercise_Name = "Abdominal Crunch"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=6
                Exercise_Link = "https://drive.google.com/file/d/1kUFRV7h7_NcEv2sfdGsUb8nK-TlhxoKx/view?usp=drive_link",
                Exercise_Name = "Superman"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=7
                Exercise_Link = "https://drive.google.com/file/d/1haj5CKHawx793CwvOjw10p-9ZexNqrdS/view?usp=drive_link",
                Exercise_Name = "Extended Leg Pulses"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=8
                Exercise_Link = "https://drive.google.com/file/d/1e7hvDDJs6cVJu4K5AfCWfnz6G190ywUj/view?usp=drive_link",
                Exercise_Name = "Side Lunges"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=9
                Exercise_Link = "https://drive.google.com/file/d/13b1XcuscMVc3eN_iF_C7ML6guCpEgZq7/view?usp=drive_link",
                Exercise_Name = "Lunge"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=10
                Exercise_Link = "https://drive.google.com/file/d/1yooKetk-HmFS2OlcUp8q4kdzfwhcHaPs/view?usp=drive_link",
                Exercise_Name = "Standing Quad Stretch"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=11
                Exercise_Link = "https://drive.google.com/file/d/1g6Sdola8-EuqPGYuodJeItLi9AGiFKtf/view?usp=drive_link",
                Exercise_Name = "Forward Fold"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=12
                Exercise_Link = "https://drive.google.com/file/d/1SSC-8bOfscHoOrGqiOI-sL9a2MQWND_z/view?usp=drive_link",
                Exercise_Name = "Seated Shoulder Squeeze"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=13
                Exercise_Link = "https://drive.google.com/file/d/1kHgfX2W3bAB8hplhwR0FH8kAuKxRZZ_q/view?usp=drive_link",
                Exercise_Name = "90/90 Stretch"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=14
                Exercise_Link = "https://drive.google.com/file/d/1YmQsm7MAFOzFEx2Y0GTjvnriK9yCgqs4/view?usp=drive_link",
                Exercise_Name = "Triceps Stretch"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=15
                Exercise_Link = "https://drive.google.com/file/d/16X8n8hRPboZLuRWGsxBIN3qnB0VVRKyb/view?usp=drive_link",
                Exercise_Name = "Toes on Wall Calf Stretch"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=16
                Exercise_Link = "https://drive.google.com/file/d/1aUF5sUcpwLDDeLnYMyOy4vcb8BAP3WqH/view?usp=drive_link",
                Exercise_Name = "Piriformis Stretch"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=17
                Exercise_Link = "https://drive.google.com/file/d/1Q48yM1vC212842LQYw35_R8mdRkiDGRB/view?usp=drive_link",
                Exercise_Name = "Plantar Flexion"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=18
                Exercise_Link = "https://drive.google.com/file/d/1LdLLkuTsnU7CcTCfHC-Jr6kw8ki6VP9I/view?usp=drive_link",
                Exercise_Name = "Side Leg Raise"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=19
                Exercise_Link = "https://drive.google.com/file/d/1ZBtnUEpP9dRMhqizphZSvlMtsObP4xYW/view?usp=drive_link",
                Exercise_Name = "Knee Extension"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=21
                Exercise_Link = "https://drive.google.com/file/d/1IoNvOF9rBYJ4WSuFx69U1jWYz7o7XqIR/view?usp=drive_link",
                Exercise_Name = "Hip Extension"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=22
                Exercise_Link = "https://drive.google.com/file/d/1ZBtnUEpP9dRMhqizphZSvlMtsObP4xYW/view?usp=drive_link",
                Exercise_Name = "Knee Extension"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=23
                Exercise_Link = "https://drive.google.com/file/d/1bxV1CkDF5YT1wTr5IvJTF8mN_iZ8g71K/view?usp=drive_link",
                Exercise_Name = "Jogging"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=24
                Exercise_Link = "https://drive.google.com/file/d/1nalkukzLvmhCQ900BSDLd6R6y_KlGLdI/view?usp=drive_link",
                Exercise_Name = "Rowing"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=25
                Exercise_Link = "https://drive.google.com/file/d/1TYgbZx3Jel01lhvtquOu7sZxdga1FRGj/view?usp=drive_link",
                Exercise_Name = "Biking"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=26
                Exercise_Link = "https://drive.google.com/file/d/1QfcGOOoRnXpagHTnRgaG_0E88SyCVutn/view?usp=drive_link",
                Exercise_Name = "Treadmill"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=27
                Exercise_Link = "https://drive.google.com/file/d/1YSW1X3Ha_MPsJ-mFa2sbMB6yOjYRTVyx/view?usp=drive_link",
                Exercise_Name = "Dumbbell Renegade Row"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=28
                Exercise_Link = "https://drive.google.com/file/d/1O1sbXjxSwqDtFsH_9fPHsrfhB3uKXeHj/view?usp=drive_link",
                Exercise_Name = "Dumbbell Clusters"
            });


            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=29
                Exercise_Link = "https://drive.google.com/file/d/1LYYfrETAl2pNqSr7Au2-YCqJh4_fYQZ6/view?usp=drive_link",
                Exercise_Name = "Dumbbell Squat to Overhead Press"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=30
                Exercise_Link = "https://drive.google.com/file/d/1BR6o7w5IX1O7nQJmzOz3oH33VVKP32-p/view?usp=drive_link",
                Exercise_Name = "V-Up Crunches"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=31
                Exercise_Link = "https://drive.google.com/file/d/1BR6o7w5IX1O7nQJmzOz3oH33VVKP32-p/view?usp=drive_link",
                Exercise_Name = "V-Up Crunches"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=32
                Exercise_Link = "https://drive.google.com/file/d/1E6FthE-c6MIoaqZGu47GcLlz9vNZDpCA/view?usp=drive_link",
                Exercise_Name = "Double Leg Butt Kick"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=33
                Exercise_Link = "https://drive.google.com/file/d/1ouvbG2U7qjQl3HoldhfJUwwbAR-rhrM6/view?usp=drive_link",
                Exercise_Name = "Push-Ups"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=34
                Exercise_Link = "https://drive.google.com/file/d/17P3JuyCgRqzCM0zTPwo-iOLfxcf7-a1i/view?usp=drive_link",
                Exercise_Name = "Dumbbell Power Maker"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=35
                Exercise_Link = "https://drive.google.com/file/d/1N8C4jaDZAXCeFfZufZgqYH_rWjXkTs3A/view?usp=drive_link",
                Exercise_Name = "Bicycle Crunches"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=36
                Exercise_Link = "https://drive.google.com/file/d/1NYJyVDcVoH-A5kiJg3yUceUlI0vs-SYa/view?usp=drive_link",
                Exercise_Name = "Mountain Climbers"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=37
                Exercise_Link = "https://drive.google.com/file/d/1viJXLjJnQ4wxGn-X3N3ZQLHvMseIfFTq/view?usp=drive_link",
                Exercise_Name = "Jumping Split Lunges"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=38
                Exercise_Link = "https://drive.google.com/file/d/1-5e_janwbyuRViRjk3Ni6tM9-yaxT9Jl/view?usp=drive_link",
                Exercise_Name = "Russian Twist"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=39
                Exercise_Link = "https://drive.google.com/file/d/1b4oU_dxhM-kwR0Qh51CxroxzunpoFkrI/view?usp=drive_link",
                Exercise_Name = "Vertical Jumps"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=40
                Exercise_Link = "https://drive.google.com/file/d/1QKrundu22fbE9RhlcCH_QjEjdtEWywNM/view?usp=drive_link",
                Exercise_Name = "Shoulder Tap"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=41
                Exercise_Link = "https://drive.google.com/file/d/1WdF5Sqez_JHGEfS7C_XBduueBV17KokP/view?usp=drive_link",
                Exercise_Name = "Plank"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=42
                Exercise_Link = "https://drive.google.com/file/d/1SqgyKg02DxHRAlR6MXiE2sy3RzTiV3Xw/view?usp=drive_link",
                Exercise_Name = "Dumbbell Step-up"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=43
                Exercise_Link = "https://drive.google.com/file/d/1CtY2ogzl51zLbLiSx8dENtG-hM_8Asf0/view?usp=drive_link",
                Exercise_Name = "Frog Squat Jump"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=44
                Exercise_Link = "https://drive.google.com/file/d/1w6MqCn4f8o2R0PNlOP09LPUtNFa4yGob/view?usp=drive_link",
                Exercise_Name = "Sit-up"
            });


            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=45
                Exercise_Link = "https://drive.google.com/file/d/1Uygvk3ZkB9PLofwF2ZEFrcUcRBiP45K-/view?usp=drive_link",
                Exercise_Name = "Step Up"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=46
                Exercise_Link = "https://drive.google.com/file/d/1JUaWxIaId2Btta85rrWMAmYKGEs6xB4C/view?usp=drive_link",
                Exercise_Name = "Skater Jumps"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=47
                Exercise_Link = "https://drive.google.com/file/d/1ukjOykQGGuQ_isCQKOhP5SIKRCQidAuv/view?usp=drive_link",
                Exercise_Name = "Ankel Hops"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=48
                Exercise_Link = "https://drive.google.com/file/d/1yCQWAG5KgpJx8AqhbJYWbADaqzu9zg0E/view?usp=drive_link",
                Exercise_Name = "Calf Raises"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=49
                Exercise_Link = "https://drive.google.com/file/d/1loT2RhMrclS7ZWikTeyd2VtoIvdlPpyM/view?usp=drive_link",
                Exercise_Name = "Jumping Jacks"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=50
                Exercise_Link = "https://drive.google.com/file/d/1dP0BDT7DCbJcrtIok7ddQPZZwEUE2Nyr/view?usp=drive_link",
                Exercise_Name = "High Knees"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=51
                Exercise_Link = "https://drive.google.com/file/d/1kz_KPOrT8hawtydhjy_tnLli_lunCcvU/view?usp=drive_link",
                Exercise_Name = "Lunges"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=52
                Exercise_Link = "https://drive.google.com/file/d/1Mvfz919GO_ezoM3hWvovl-mHflEGYO_2/view?usp=drive_link",
                Exercise_Name = "Bench Press"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=53
                Exercise_Link = "https://drive.google.com/file/d/12TxsFiYUJm_pvT6VVL1kV4Ks6KvckCby/view?usp=drive_link",
                Exercise_Name = "Squats"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=54
                Exercise_Link = "https://drive.google.com/file/d/1tih-jKivSvNgUPgK4zE_UVdxuPm0Up-d/view?usp=drive_link",
                Exercise_Name = "Leg Extension"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=55
                Exercise_Link = "https://drive.google.com/file/d/1QYBcFMy-7oypUKJ50OW20VG0cFAQqsio/view?usp=drive_link",
                Exercise_Name = "Tricep Extension"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=56
                Exercise_Link = "https://drive.google.com/file/d/1SxwdUzLGVm3xI664BTChQDYgqdJTreO1/view?usp=drive_link",
                Exercise_Name = "Leg Press"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=57
                Exercise_Link = "https://drive.google.com/file/d/1238sqF0lycwPk69_HiJMrrEq9yqA3Ylk/view?usp=drive_link",
                Exercise_Name = "Lateral Pull Down"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=58
                Exercise_Link = "https://drive.google.com/file/d/19TDr19ma4_OwPzaWSI2GJRrydNzaeqvX/view?usp=drive_link",
                Exercise_Name = "Shoulder Press"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=59
                Exercise_Link = "https://drive.google.com/file/d/1QdIv1CO69Hsx30r17TxalKsLQWrtUX0t/view?usp=drive_link",
                Exercise_Name = "Bicep Curl"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=60
                Exercise_Link = "https://drive.google.com/file/d/1Zy1mbUcoV9USxXyU5wQ3Cpxcva_6PKMu/view?usp=drive_link",
                Exercise_Name = "Chest Press"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=61
                Exercise_Link = "https://drive.google.com/file/d/1AfiPWFympupS7D4VwUifghkLgugyZtse/view?usp=drive_link",
                Exercise_Name = "Hamstring Curls"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=62
                Exercise_Link = "https://drive.google.com/file/d/1hGz4fCznueh5aXrYVIROhnO3M4EwBMQh/view?usp=drive_link",
                Exercise_Name = "Squat Jumps"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=63
                Exercise_Link = "https://drive.google.com/file/d/1RjNWEdpfyN4LesDn9sZO2_-fVG3PyYUb/view?usp=drive_link",
                Exercise_Name = "Lunging Hip Flexor Stretch"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=64
                Exercise_Link = "https://drive.google.com/file/d/11DoUqYKwrIgMu3WD0qYDdU9VYYxnMKsG/view?usp=drive_link",
                Exercise_Name = "Lunge with Spinal Twist"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=65
                Exercise_Link = "https://drive.google.com/file/d/1KfiWss8VrT7oXEFqEdzYLbfVjjfybV9e/view?usp=drive_link",
                Exercise_Name = "Lying Pectoral Stretch"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=66
                Exercise_Link = "https://drive.google.com/file/d/1zkqYqdgEKebnXZ8ISbL_edN-3uPg0V0M/view?usp=drive_link",
                Exercise_Name = "Figure Four Stretch"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=67
                Exercise_Link = "https://drive.google.com/file/d/1_GBbAL_4pDcoKR2B0jvYhQKlqnWJzj1N/view?usp=drive_link",
                Exercise_Name = "Pelvic Tilt"
            });

            _dbExerciseDatabase.AddItem(new ExerciseDatabase
            {
                //Id=68
                Exercise_Link = "https://drive.google.com/file/d/1WWIh2HXYQt_bFyxEbaxBWP-ENruu1Lu4/view?usp=drive_link",
                Exercise_Name = "Squats"
            });
        }

        private DatabaseManager<T> LoadDatabase<T>() where T : new()
        {
            string fileName = "ExerciseDatabase.db3";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(folderPath, fileName);


            return new DatabaseManager<T>(dbPath);
        }
    }
}