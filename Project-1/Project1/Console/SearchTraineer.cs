using Business_Logic;
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
        //IData repo = new SqlRepo(conStr);
        ILog repo = new Logic(conStr);
        public void Display()
        {
            Console.Clear();
            System.Console.WriteLine("Welcome to Search Page");
            System.Console.WriteLine("Choose One Of The Option Below To Continue");
            System.Console.WriteLine("[0] To Go Back");
            System.Console.WriteLine("[1] Search Trainer By Email          : ");
            System.Console.WriteLine("[2] search Trainer By Skillname      : ");
            System.Console.WriteLine("[3] Search Trainer By Experience     : ");
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
                case "2":
                    Console.WriteLine("Please Enter Skill name to Search");
                    string skillname = Console.ReadLine();
                    var listoftrainers = repo.GetAllTrainersBySkillname(skillname);
                    foreach (var r in listoftrainers)
                    {
                        System.Console.WriteLine("**********************************");
                        //System.Console.WriteLine(r.ToString());
                        System.Console.WriteLine(r.TrainerDetails());
                    }
                    Log.Information("Reading Trainers ends By skills");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "SearchTrainer";
                case "3":
                    Console.WriteLine("Please Enter Experience to Search");
                    string Exp = Console.ReadLine();
                    var searchtrainer = repo.SearchByExperience(Exp);
                    foreach (var r in searchtrainer)
                    {
                        System.Console.WriteLine("**********************************");
                        //System.Console.WriteLine(r.ToString());
                        System.Console.WriteLine(r.TrainerDetails());
                    }
                    Log.Information("Reading Trainers ends By Experience");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "Searchtrainer";

            }

            return "Menu";

        }
    }
}
