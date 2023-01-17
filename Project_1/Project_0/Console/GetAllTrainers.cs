using TrainersData;
using System;

namespace Console
{
    internal class GetAllTrainers : IAlldetails
    {
        static string conStr = File.ReadAllText("../../../connectionString.txt");
        IData repo = new SqlRepo(conStr);

        public void Display()
        {
            System.Console.WriteLine("Please select an option to filter the Trainers database");
            System.Console.WriteLine("[3] to get all trainers");
            System.Console.WriteLine("[2] to Login");
            System.Console.WriteLine("[1] to Signup");
            System.Console.WriteLine("[0] Go back");
        }

        public string UserChoice()
        {
            System.Console.Write("Enter your choice: ");
            string userChoice = System.Console.ReadLine();

            switch (userChoice)
            {
                case "0":
                    return "Alldetails";
                case "1":
                    return "SignUp";
                case "2":
                    return "Login";
                case "3":
                    Log.Information("Getting all trainers");
                    var listOfTrainers = repo.GetAllTrainersDisconnected();
                    Log.Information($"Got list of {listOfTrainers.Count} restaurants");
                    Log.Information("Reading Trainers about to start");
                    foreach (var r in listOfTrainers)
                    {
                        System.Console.WriteLine("================");
                        System.Console.WriteLine(r.ToString());
                        System.Console.WriteLine(r.TrainerDetails());
                    }
                    Log.Information("Reading restaurants ends");
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

