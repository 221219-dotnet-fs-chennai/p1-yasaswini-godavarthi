using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
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
            System.Console.WriteLine("What would you like to do?");
            System.Console.WriteLine("[2] Get all Trainers details");
            System.Console.WriteLine("[1] Add a new Trainer");
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
                    return "AddTrainer";
                case "2":
                    return "GetTrainers";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "Alldetails";
            }
        }
    }
}
