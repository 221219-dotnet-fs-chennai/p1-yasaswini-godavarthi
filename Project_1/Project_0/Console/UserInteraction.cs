using TrainersData;

namespace Console1
{
    class UserInteraction : IAlldetails
    {
        Details trainerProfile = new Details();

        static string conStr = File.ReadAllText("../../../connectionString.txt");

        IData repo = new SqlRepo(conStr);
        public UserInteraction(Details trainer)
        {
            trainerProfile = trainer;
            System.Console.WriteLine(trainerProfile.ToString());
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
                List<Details> data = repo.GetAllTrainerDetails(1);
                foreach (Details details in data)
                {
                    Console.WriteLine(details.detail());
                }
            }
            if (i == "3")
            {
                List<Details> data = repo.GetAllTrainerDetails(3);
                foreach (Details details in data)
                {
                    Console.WriteLine(details.skills());
                }
            }
            if (i == "4")
            {
                List<Details> data = repo.GetAllTrainerDetails(4);
                foreach (Details details in data)
                {
                    Console.WriteLine(details.company());
                }
            }
            if (i == "2")
            {
                List<Details> data = repo.GetAllTrainerDetails(2);
                foreach (Details details in data)
                {
                    Console.WriteLine(details.edu());
                }
            }
            return "ShowDetails";
        }
    }
}
