using System;
namespace Console1
{
    public class AddTrainer : IAlldetails
    {
        public void Display()
        {
            System.Console.WriteLine("[1] to Login");
            System.Console.WriteLine("[2] to Signup");
            System.Console.WriteLine("[3] to Main Menu");
        }

        public string UserChoice()
        {
            System.Console.Write("Enter your choice: ");
            string userChoice = System.Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    return "Login";
                case "2":
                    return "Signup";
                case "3":
                    return "Menu";
                default:
                    System.Console.WriteLine("Wrong Choice! Try again...");
                    System.Console.WriteLine("Enter to Continue...");
                    System.Console.ReadLine();
                    return "AddTrainer";
            }
        }
    }
}