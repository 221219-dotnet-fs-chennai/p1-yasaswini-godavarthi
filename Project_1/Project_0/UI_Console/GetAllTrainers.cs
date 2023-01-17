using TrainersData;
using System;

namespace UI_Console
{
    public class GetAllTrainers : IAlldetails
    {
        static string conStr = File.ReadAllText("../../../connectionString.txt");

        public void Display()
        {
            Console.WriteLine("Please select an option to filter the Trainers database");
            Console.WriteLine("[2] to Login");
            Console.WriteLine("[1] to Signup");
            Console.WriteLine("[0] Go back");
        }

        public string UserChoice()
        {
            System.Console.Write("Enter your choice: ");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "0":
                    return "Alldetails";
                case "1":
                    return "Signup";
                case "2":
                    return "Login";
                default:
                    Console.WriteLine("Wrong Choice! Try again...");
                    Console.WriteLine("Enter to Continue...");
                    Console.ReadLine();
                    return "GetAllTrainers";

            }
        }
    }
}
