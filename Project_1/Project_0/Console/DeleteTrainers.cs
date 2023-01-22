using Console1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TrainersData;

namespace Console1
{
    internal class DeleteTrainers : SignUp, IAlldetails
    {
        Details trainerProfile = new Details();

        static string conStr = File.ReadAllText("../../../connectionString.txt");

        IData repo = new SqlRepo(conStr);
        public DeleteTrainers()
        {

        }
        public DeleteTrainers(Details details)
        {
            trainerProfile = details;
        }

        public void Display()
        {
            Console.WriteLine("Please Choose one option to delete the data");
            System.Console.WriteLine("[0] To go back           :");
            System.Console.WriteLine("[1]Fullname              : " + trainerProfile.Full_name);
            System.Console.WriteLine("[2]Age                   : " + trainerProfile.Age);
            System.Console.WriteLine("[3]Gender                : " + trainerProfile.Gender);
           // System.Console.WriteLine("[4]Phone number        : " + trainerProfile.Mobile_number);
            System.Console.WriteLine("[4]Website               : " + trainerProfile.Website);
            System.Console.WriteLine("[5]Highest Qualification : " + trainerProfile.Highest_Graduation);
            System.Console.WriteLine("[6]Institute             : " + trainerProfile.Institute);
            System.Console.WriteLine("[7]Department            : " + trainerProfile.Department);
            System.Console.WriteLine("[8]Start Year            : " + trainerProfile.Start_year);
            System.Console.WriteLine("[9]End Year              : " + trainerProfile.End_year);
            System.Console.WriteLine("[10]Skill name           : " + trainerProfile.Skill_name);
            System.Console.WriteLine("[11]Skill Type           : " + trainerProfile.Skill_Type);
            System.Console.WriteLine("[12]Skill Level          : " + trainerProfile.Skill_Level);
            System.Console.WriteLine("[13]Company name         : " + trainerProfile.Company_name);
            System.Console.WriteLine("[14]Company Type         : " + trainerProfile.Company_type);
            System.Console.WriteLine("[15]Experience           : " + trainerProfile.Experience);
            System.Console.WriteLine("[16]company Desc         : " + trainerProfile.Company_Description);
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
                    System.Console.WriteLine(".......Deleting Full Name......");
                    repo.DeleteTrainer("Full_name", "Trainer_Detailes", details.user_id);
                    return "TrainerUpdate";
                case "2":
                    System.Console.WriteLine(".......Deleting Age.......");
                    repo.DeleteTrainer("Age", "Trainer_Detailes", details.user_id);
                    return "TrainerUpdate";
                case "3":
                    System.Console.WriteLine(".......Deleting Gender.......");
                    repo.DeleteTrainer("Gender", "Trainer_Detailes", details.user_id);
                    return "TrainerUpdate";

                case "4":
                    System.Console.WriteLine(".......Deleting Website.......");
                    repo.DeleteTrainer("Age", "Trainer_Detailes", details.user_id);
                    return "TrainerUpdate";

                case "5":
                    System.Console.WriteLine(".......Deleting Qualification.......");
                    repo.DeleteTrainer("Highest_Graduation", "Education_Details", details.user_id);
                    return "TrainerUpdate";

                case "6":
                    System.Console.WriteLine(".......Deleting Institute.......");
                    repo.DeleteTrainer("Institute", "Education_Details", details.user_id);
                    return "TrainerUpdate";

                case "7":
                    System.Console.WriteLine(".......Deleting Department.......");
                    repo.DeleteTrainer("Department", "Education_Details", details.user_id);
                    return "TrainerUpdate";

                case "8":
                    System.Console.WriteLine(".......Deleting Start_year......");
                    repo.DeleteTrainer("Start_year", "Education_Details", details.user_id);
                    return "TrainerUpdate";
                case "9":
                    System.Console.WriteLine(".......Deleting Qualification.......");
                    repo.DeleteTrainer("End_year", "Education_Details", details.user_id);
                    return "TrainerUpdate";
                case "10":
                    System.Console.WriteLine(".......Deleting Skill name.......");
                    repo.DeleteTrainer("Skill_name", "Skills", details.user_id);
                    return "TrainerUpdate";
                case "11":
                    System.Console.WriteLine(".......Deleting Skill type.......");
                    repo.DeleteTrainer("Skill_Type", "Skills", details.user_id);
                    return "TrainerUpdate";
                case "12":
                    System.Console.WriteLine(".......Deleting Skill Level.......");
                    repo.DeleteTrainer("Skill_Level", "Skills", details.user_id);
                    return "TrainerUpdate";
                case "13":
                    System.Console.WriteLine(".......Deleting Company name......");
                    repo.DeleteTrainer("Company_name", "Company", details.user_id);
                    return "TrainerUpdate";
                case "14":
                    System.Console.WriteLine(".......Deleting Company type......");
                    repo.DeleteTrainer("Company_type", "Company", details.user_id);
                    return "TrainerUpdate";
                case "15":
                    System.Console.WriteLine(".......Deleting Experience......");
                    repo.DeleteTrainer("Experience", "Company", details.user_id);
                    return "TrainerUpdate";
                case "16":
                    System.Console.WriteLine(".......Deleting Company Description......");
                    repo.DeleteTrainer("Company_Description", "Company", details.user_id);
                    return "TrainerUpdate";
                default:
                    System.Console.WriteLine("------------------------------");
                    System.Console.WriteLine("Wrong choice, Try again!");
                    System.Console.WriteLine("Enter to continue");
                    System.Console.ReadLine();
                    return "TrainerUpdate";

            }
        }
    }
}
