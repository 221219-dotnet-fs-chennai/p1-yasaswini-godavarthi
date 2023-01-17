using TrainersData;
using System;

namespace Console
{
    public class GetAllTrainers : IAlldetails
    {
        static string conStr = File.ReadAllText("../../../connectionString.txt");

        public void Display()
        {
            System.Console.WriteLine("Please select an option to filter the Trainers database");
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
                    return "Signup";
                case "2":
                    return "Login";
                default:
                    System.Console.WriteLine("Wrong Choice! Try again...");
                    System.Console.WriteLine("Enter to Continue...");
                    System.Console.ReadLine();
                    return "GetAllTrainers";

            }
        }
    }
}
/*namespace UI_Console
{
    public class TrainerMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("[0] to Main Menu");
            Console.WriteLine("[1] to Login");
            Console.WriteLine("[2] to Signup");
        }

        public string UserChoice()
        {
            Console.Write("Enter your choice: ");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    return "Login";
                case "2":
                    return "Signup"; 
                default:
                    Console.WriteLine("Wrong Choice! Try again...");
                    Console.WriteLine("Enter to Continue...");
                    Console.ReadLine();
                    return "TrainerMenu";
            }
        }
    }
}
*/
