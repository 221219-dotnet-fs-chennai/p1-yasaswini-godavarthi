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
        private string email;
        public DeleteTrainers()
        {

        }
        DeleteTrainers(string email)
        {
            this.email = email;
        }

        public void Display()
        {
            Console.WriteLine("Please Choose one option to delete the data");
            Console.WriteLine("[0] To go back");
            Console.WriteLine("[1] Mobile_number \n [2] Website \n [3] Skill_name \n [4] Skill_Type \n [5] Skill_Level \n [6] Company_name \n");
            Console.WriteLine("[7] Company_type \n [8] Experience  \n [9] Highest_Graduation \n [10] Institute \n [11] Department ");
            Console.WriteLine("\n [12] Start_year \n [13] End_year \n");
        }

        public string UserChoice()
        {
            Console.Write("Please Enter your choice:");
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "0":
                    return "TrainerUpdate";
                case "1":

                    return "DeleteTrainer";

            }
            return "DeleteTrainer";
        }
    }
}
