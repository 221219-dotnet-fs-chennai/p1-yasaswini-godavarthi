using TrainersData;
using System;
using Business_Logic;

namespace Console1
{
    internal class GetAllTrainers : IAlldetails
    {
        static string conStr = File.ReadAllText("../../../connectionString.txt");

        // IData repo = new SqlRepo(conStr);
        ILog repo = new Logic(conStr);
        

        public void Display()
        {
            System.Console.WriteLine("Please select an option to filter the Trainers database");
            System.Console.WriteLine("[1] Proceed to get all trainers");
            System.Console.WriteLine("[0] Go back");
        }

        public string UserChoice()
        {
            System.Console.Write("Enter your choice: ");
            string userChoice = System.Console.ReadLine();

            switch (userChoice)
            {
                case "0":
                    return "Menu";
                case "1":
                    Log.Information("Getting all trainers");
                    var listOfTrainers = repo.GetAllTrainersDisconnected();
                    Log.Information($"Got list of {listOfTrainers.Count()} Trainers");
                    Log.Information("Reading Trainers about to start");
                    foreach (var r in listOfTrainers)
                    {
                        System.Console.WriteLine("**********************************");
                        //System.Console.WriteLine(r.ToString());
                        System.Console.WriteLine(r.TrainerDetails());
                    }
                    Log.Information("Reading Trainers ends");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();

                    return "GetAllTrainers";
                default:
                    System.Console.WriteLine("Wrong Choice! Try again...");
                    System.Console.WriteLine("Enter to Continue...");
                    System.Console.ReadLine();
                    return "GetAllTrainers";

            }
        }
    }
}

