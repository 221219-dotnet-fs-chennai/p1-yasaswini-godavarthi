using TrainersData;

namespace Console1
{
    class UserInteraction : IAlldetails
    {
        Details trainerProfile = new Details();

        static string conStr = File.ReadAllText("../../../connectionString.txt");

        IData repo = new SqlRepo(conStr);
        public UserInteraction()
        {

        }
        string Email;
        public UserInteraction(Details detail)
        {
            trainerProfile = detail;
        }
        public void Display()
        {
            System.Console.WriteLine($"Welcome {trainerProfile.Full_name} :)");
            System.Console.WriteLine("Choose below options to perform actions\n");
            System.Console.WriteLine("[0] to Back");
            System.Console.WriteLine("[1] For to get Trainer details");
            System.Console.WriteLine("[2] For to get Trainer Educational details");
            System.Console.WriteLine("[3] For to get Trainer Skills");
            System.Console.WriteLine("[4] For to get Trainer Previous Experience");
        }

        public string UserChoice()
        {
            System.Console.WriteLine("--------------------------");
            System.Console.Write("\nEnter your choice: ");
            string userChoice = System.Console.ReadLine();

            switch (userChoice)
            {
                case "0":
                    return "TrainerUpdate";
                case "1":
                    System.Console.WriteLine("--------------------------------------");
                    System.Console.WriteLine("Getting trainer details...");
                    ShowProfile("1");
                    System.Console.ReadLine();
                    return "ShowDetails";
                case "2":
                    System.Console.WriteLine("--------------------------------------");
                    System.Console.WriteLine("Getting trainer Education Details...");
                    ShowProfile("2");
                    System.Console.ReadLine();
                    return "UserInteraction";
                case "3":
                    System.Console.WriteLine("--------------------------------------");
                    System.Console.WriteLine("Getting trainer skills...");
                    ShowProfile("3");
                    System.Console.ReadLine();
                    return "UserInteraction";
                case "4":
                    System.Console.WriteLine("--------------------------------------");
                    System.Console.WriteLine("Getting trainer Company details...");
                    ShowProfile("4");
                    System.Console.ReadLine();
                    return "UserInteraction";
                default:
                    System.Console.WriteLine("Wrong choice try again");
                    System.Console.WriteLine("Press Enter to continue");
                    System.Console.ReadLine();
                    return "UserInteraction";
            }
        }

        public string ShowProfile(string i)
        {
            Log.Logger.Information("Reading Trainer Details");
            if (i == "1")
            {
                System.Console.WriteLine("User_id             : " + trainerProfile.user_id);
                System.Console.WriteLine("Password            : " + trainerProfile.PASSWORD);
                System.Console.WriteLine("Fullname            : " + trainerProfile.Full_name);
                System.Console.WriteLine("Age                 : " + trainerProfile.Age);
                System.Console.WriteLine("Gender              : " + trainerProfile.Gender);
                System.Console.WriteLine("Phone number        : " + trainerProfile.Mobile_number);
                System.Console.WriteLine("Website             : " + trainerProfile.Website);
                System.Console.WriteLine("Email               : " + trainerProfile.Email);
            }
            if (i == "2")
            {
                System.Console.WriteLine("User_id               : " + trainerProfile.user_id);
                System.Console.WriteLine("Highest Qualification : " + trainerProfile.Highest_Graduation);
                System.Console.WriteLine("Institute             : " + trainerProfile.Institute);
                System.Console.WriteLine("Department            : " + trainerProfile.Department);
                System.Console.WriteLine("Start Year            : " + trainerProfile.Start_year);
                System.Console.WriteLine("End Year               : " + trainerProfile.End_year);
            }
            if (i == "3")
            {
                System.Console.WriteLine("User_id              : " + trainerProfile.user_id);
                System.Console.WriteLine("Skill name           : " + trainerProfile.Skill_name);
                System.Console.WriteLine("Skill Type           : " + trainerProfile.Skill_Type);
                System.Console.WriteLine("Skill Level          : " + trainerProfile.Skill_Level);
            }
            if (i == "4")
            {
                System.Console.WriteLine("User_id                 : " + trainerProfile.user_id);
                System.Console.WriteLine("[10]Company_name        : " + trainerProfile.Company_name);
                System.Console.WriteLine("[11] Company_Type       : " + trainerProfile.Company_type);
                System.Console.WriteLine("[12] Experience         : " + trainerProfile.Experience);
                System.Console.WriteLine("[13]Company_Desc        : " + trainerProfile.Company_Description);
            }
            return "ShowDetails";
        }
    }
}
