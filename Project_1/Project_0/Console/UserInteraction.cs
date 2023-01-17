using TrainersData;

namespace Console
{
    class UserInteraction : IAlldetails
    {
        Details trainerProfile = new Details();

        static string conStr = File.ReadAllText("../../../connectionString.txt");

        IData repo = new SqlRepo(conStr);
        public UserInteraction(Details trainer)
        {
            trainerProfile = trainer;
        }
        public void Display()
        {
            System.Console.WriteLine($"Welcome {trainerProfile.Full_name} :)");
            System.Console.WriteLine("Choose below options to perform actions\n");
            System.Console.WriteLine("[0] to Back");
            System.Console.WriteLine("[1] View Profile");
        }

        public string UserChoice()
        {
            System.Console.WriteLine("--------------------------");
            System.Console.Write("\nEnter your choice: ");
            string userChoice = System.Console.ReadLine();

            switch (userChoice)
            {
                case "0":
                    return "Login";
                case "1":
                    ShowProfile();
                    System.Console.WriteLine("--------------------------------------");
                    System.Console.WriteLine("Press Enter to continue...");
                    System.Console.ReadLine();
                    return "UserInteraction";
                default:
                    System.Console.WriteLine("Wrong choice try again");
                    System.Console.WriteLine("Press Enter to continue");
                    System.Console.ReadLine();
                    return "UserInteraction";
            }
        }

        public void ShowProfile()
        {
            System.Console.Clear();

            System.Console.WriteLine($"\n-------{trainerProfile.Full_name.ToUpper()} PROFILE-------\n");
            System.Console.WriteLine("Email                : " + trainerProfile.Email);
            System.Console.WriteLine("Password             : " + trainerProfile.Password);
            System.Console.WriteLine("Full_name            : " + trainerProfile.Full_name);
            System.Console.WriteLine("Age                  : " + trainerProfile.Age);
            System.Console.WriteLine("Gender               : " + trainerProfile.Gender);
            System.Console.WriteLine("Phone number         : " + trainerProfile.Mobile_Number);
            System.Console.WriteLine("Website              : " + trainerProfile.Website);
            System.Console.WriteLine("Skill_name           : " + trainerProfile.Skill_Name);
            System.Console.WriteLine("Skill_Type           : " + trainerProfile.Skill_Type);
            System.Console.WriteLine("Skill level          : " + trainerProfile.Skill_Level);
            System.Console.WriteLine("Company name         : " + trainerProfile.Company_name);
            System.Console.WriteLine("Company type         : " + trainerProfile.Company_type);
            System.Console.WriteLine("Experience           : " + trainerProfile.Experience);
            System.Console.WriteLine("Company desc         : " + trainerProfile.Company_Description);
            System.Console.WriteLine("Highest Qualification: " + trainerProfile.Highest_Graduation);
            System.Console.WriteLine("Institute            : " + trainerProfile.Institute);
            System.Console.WriteLine("Department           : " + trainerProfile.Department);
            System.Console.WriteLine("Start_year           : " + trainerProfile.Start_year);
            System.Console.WriteLine("End Year             : " + trainerProfile.End_year);
        }
    }
}
