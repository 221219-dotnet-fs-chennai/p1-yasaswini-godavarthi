using Console1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainersData;

namespace Console1
{
    internal class DeleteTrainers : IAlldetails
    {
        static string conStr = File.ReadAllText("../../../connectionString.txt");

        IData repo = new SqlRepo(conStr);
        public void Display()
        {
            Console.WriteLine("[0] To go back");
            Console.WriteLine("[1] Proceed to delete Trainer");
        }

        public string UserChoice()
        {
            /*Console.Write("Please Enter your choice:");
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "0":
                    return "MainMenu";
                case "1":


            }*/
            return "";
        }
    }
}
