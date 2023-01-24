using Console1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainersData;

namespace Console1
{
    internal class SearchTraineer : IAlldetails
    {
        static string conStr = File.ReadAllText("../../../connectionString.txt");
        IData repo = new SqlRepo(conStr);
        public void Display()
        {
            Console.Clear();
            System.Console.WriteLine("Welcome to Search Page");
            System.Console.WriteLine("Choose One Of The Option Below To Continue");
            System.Console.WriteLine("[0] To Go Back");
            System.Console.WriteLine("[1] Search Trainer By Email          : ");
        }

        public string UserChoice()
        {
            System.Console.WriteLine("Please Enter Your Choice :");
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "0":
                    return "Menu";
                case "1":
                    repo.SearchByEmail();
                    
                    Console.ReadLine();
                    return "SearchTrainer";

            }

            return "Menu";

        }
    }
}
