using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console1
{
    /*
     MainMenu inherits IMenu interface but since it is a class it needs to give actual implementation details to the methods
     stated inside of the interface
 */
    internal class Alldetails : IAlldetails
    {
        public void Display()
        {
            System.Console.WriteLine("Welcome to Trainers page!");
            System.Console.WriteLine("[4] search trainer");
            System.Console.WriteLine("[3] get all trainers");
            System.Console.WriteLine("[2] Login");
            System.Console.WriteLine("[1] Signup");
            System.Console.WriteLine("[0] Exit");
        }

        public string UserChoice()
        {
            string userInput = System.Console.ReadLine();

            //Switch cases are just useful if you are doing a bunch of comparison
            switch (userInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "Signup";
                case "2":
                    return "Login";
                case "3":
                    return "GetAllTrainers";
                case "4":
                    return "SearchTrainer";
                default:
                    System.Console.WriteLine("Enter a valid response");
                    System.Console.WriteLine("press Enter to continue");
                    System.Console.ReadLine();
                    return "Alldetails";
            }
        }
    }
}
