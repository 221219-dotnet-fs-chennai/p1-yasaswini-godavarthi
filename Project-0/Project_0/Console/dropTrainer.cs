using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainersData;

namespace Console1
{
    internal class dropTrainer : SignUp , IAlldetails
    {
        Details trainerProfile = new Details();

        static string conStr = File.ReadAllText("../../../connectionString.txt");

        IData repo = new SqlRepo(conStr);
        public dropTrainer()
        {

        }
        public dropTrainer(Details details)
        {
            trainerProfile = details;
        }
        public void Display()
        {
            System.Console.WriteLine($"Welcome {details.Full_name} :)");
            System.Console.WriteLine("Choose below options to perform Drop trainer\n");
            System.Console.WriteLine("[0] to Back");
            System.Console.WriteLine("[1] For to Delete Trainer");

        }
        public string UserChoice()
        {
            Console.Write("Please Enter Your Option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "0":
                    return "TrainerUpdate";
                case "1":
                    repo.droptrainer(details.user_id);
                    return "Menu"; 
            }
            return "DropTrainer";
        }
    }
}
