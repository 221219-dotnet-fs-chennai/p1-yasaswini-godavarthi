using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TrainersData;

namespace Console1
{
    internal class TrainerUpdate : SignUp, IAlldetails 
    {
        static string conStr = File.ReadAllText("../../../connectionString.txt");

        IData repo = new SqlRepo(conStr);
     
        public TrainerUpdate()
        {

        }
        public void Display()
        {
            System.Console.Clear();
            Console.WriteLine("[0] for to show profile data");
            Console.WriteLine("[1] for to update details");
            Console.WriteLine("[2] for to delete details");
            Console.WriteLine("[3] for to Drop Trainer");
            Console.WriteLine("[4] To for logout");
            
        }

        public string UserChoice()
        {
            System.Console.WriteLine("--------------------------");
            System.Console.Write("\nEnter your choice: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n == 0)
            {
                return "ShowDetails";
            }
            if (n == 1)
            {
                Console.Clear();
                Console.WriteLine("********* UPDATE PAGE *********");
                Console.WriteLine("[0] To go Back");
                Console.WriteLine("[1] To Update Personal Details");
                Console.WriteLine("[2] To Update Skills");
                Console.WriteLine("[3] To Update Company Details");
                Console.WriteLine("[4] To Update Educational Details");
                System.Console.WriteLine("\nselect an option to update or go back\n");
                string name = Console.ReadLine();
                ///////////////////////////////////////////////////////////////////////////////////
                if (name == "1")
                {
                    System.Console.WriteLine("\nselect an option to update or go back\n");
                    System.Console.WriteLine("[0] Go Back             : ");
                    System.Console.WriteLine("[1] Password            : " + details.PASSWORD);
                    System.Console.WriteLine("[2] Fullname            : " + details.Full_name);
                    System.Console.WriteLine("[3] Age                 : " + details.Age);
                    System.Console.WriteLine("[4] Gender              : " + details.Gender);
                    System.Console.WriteLine("[5] Phone number        : " + details.Mobile_number);
                    System.Console.WriteLine("[6] Website             : " + details.Website);
                }
                if (name == "2") {
                    System.Console.WriteLine("[0] Go Back             : ");
                    System.Console.WriteLine("[7] Skill name          : " + details.Skill_name);
                    System.Console.WriteLine("[8]Skill Type           : " + details.Skill_Type);
                    System.Console.WriteLine("[9]Skill Level          : " + details.Skill_Level);
                }
                if (name == "3")
                {
                    System.Console.WriteLine("[0] Go Back             : ");
                    System.Console.WriteLine("[10]Company_name        : " + details.Company_name);
                    System.Console.WriteLine("[11] Company_Type       : " + details.Company_type);
                    System.Console.WriteLine("[12] Experience         : " + details.Experience);
                    System.Console.WriteLine("[13]Company_Desc        : " + details.Company_Description);
                }
                if (name == "4")
                {
                    System.Console.WriteLine("[0] Go Back             : ");
                    System.Console.WriteLine("[14]Highest Qualification : " + details.Highest_Graduation);
                    System.Console.WriteLine("[15] Institute            : " + details.Institute);
                    System.Console.WriteLine("[16] Department           : " + details.Department);
                    System.Console.WriteLine("[17] Start Year           : " + details.Start_year);
                    System.Console.WriteLine("[18] End Year             : " + details.End_year);
                }
                Console.WriteLine("/n---------------------------------------------------------/n");
                Console.Write("Please Enter Your Choice To Update: ");
                string userchoice = System.Console.ReadLine();

                switch (userchoice)
                {
                    case "0":
                        return "ShowDetails";
                    case "1":
                        System.Console.Write("Enter your Password to update: ");
                        string pattern1 = @"^.* (?=.{ 8,})(?=.*\d)(?=.*[a - z])(?=.*[A - Z])(?=.*[!*@#$%^&+=]).*$";

                        string password = System.Console.ReadLine();

                        if (Regex.IsMatch(password, pattern1))
                        {
                            details.PASSWORD = password;
                            repo.UpdateTrainer("Trainer_Detailes", "Password", details.PASSWORD, details.user_id);
                        }
                        else
                        {
                            System.Console.WriteLine("Wrong pattern try again...");
                            System.Console.ReadLine();
                        }
                        return "TrainerUpdate";
                    case "2":
                        System.Console.Write("Enter your Fullname to update: ");
                        details.Full_name = System.Console.ReadLine();
                        repo.UpdateTrainer("Trainer_Detailes", "Full_name", details.Full_name, details.user_id);
                        return "TrainerUpdate";
                    case "3":
                        try
                        {
                            System.Console.Write("Enter your Age to update: ");
                            details.Age = Convert.ToInt32(System.Console.ReadLine());
                            repo.UpdateTrainer("Trainer_Detailes", "Age", Convert.ToString(details.Age), details.user_id);
                        }
                        catch (Exception ex)
                        {
                            System.Console.WriteLine("Age should be in numbers!!");
                            System.Console.WriteLine(ex.Message);
                            System.Console.ReadLine();
                        }
                        return "TrainerUpdate";
                    case "4":
                        System.Console.Write("Enter your Gender: ");
                        details.Gender = System.Console.ReadLine();
                        repo.UpdateTrainer("Trainer_Detailes", "Gender", details.Gender, details.user_id);
                        return "TrainerUpdate";

                    case "5":
                        System.Console.Write("Enter your Mobile number to update: ");
                        string pattern = @"\(?\d{3}\)?(-|.|\s)?\d{3}(-|.)?\d{4}";

                        string phone_number = System.Console.ReadLine();

                        if (Regex.IsMatch(phone_number, pattern))
                        {
                            details.Mobile_number = phone_number;
                            repo.UpdateTrainer("Trainer_Detailes", "Mobile_number", details.Mobile_number, details.user_id);
                        }
                        else
                        {
                            System.Console.WriteLine("Wrong pattern try again...");
                            System.Console.ReadLine();
                        }
                        return "TrainerUpdate";

                    case "6":
                        System.Console.Write("Enter you Website to update: ");
                        details.Website = System.Console.ReadLine();
                        repo.UpdateTrainer("Trainer_Detailes", "Website", details.Website, details.user_id);
                        return "TrainerUpdate";

                    case "7":
                        System.Console.Write("Enter your Skill name to update: ");
                        details.Skill_name = System.Console.ReadLine();
                        repo.UpdateTrainer("Skills", "Skill_name", details.Skill_name, details.user_id);
                        return "TrainerUpdate";

                    case "8":
                        System.Console.Write("Enter your Skill type to update: ");
                        details.Skill_Type = System.Console.ReadLine();
                        repo.UpdateTrainer("Skills", "Skill_Type", details.Skill_Type, details.user_id);
                        return "TrainerUpdate";

                    case "9":
                        System.Console.Write("Enter your Skill level to update: ");
                        details.Skill_Level = System.Console.ReadLine();
                        repo.UpdateTrainer("Skills", "Skill_Level", details.Skill_Level, details.user_id);
                        return "TrainerUpdate";
                    case "10":
                        System.Console.Write("Enter your Company name to update: ");
                        details.Company_name = System.Console.ReadLine();
                        repo.UpdateTrainer("Company", "Company_name", details.Company_name, details.user_id);
                        return "TrainerUpdate";
                    case "11":
                        System.Console.Write("Enter your Company type: ");
                        details.Company_type = System.Console.ReadLine();
                        repo.UpdateTrainer("Company", "Company_type", details.Company_type, details.user_id);
                        return "TrainerUpdate";
                    case "12":
                        System.Console.Write("Enter your Experience: ");
                        details.Experience = System.Console.ReadLine();
                        repo.UpdateTrainer("Company", "Experience", details.Experience, details.user_id);
                        return "TrainerUpdate";
                    case "13":
                        System.Console.Write("Enter your Company description: ");
                        details.Company_Description = System.Console.ReadLine();
                        repo.UpdateTrainer("Company", "Company_Description", details.Company_Description, details.user_id);
                        return "TrainerUpdate";
                    case "14":
                        System.Console.Write("Enter your Highest Qualification: ");
                        details.Highest_Graduation = System.Console.ReadLine();
                        repo.UpdateTrainer("Education_Details", "Highest_Graduation", details.Highest_Graduation, details.user_id);
                        return "TrainerUpdate";
                    case "15":
                        System.Console.Write("Enter your Institute: ");
                        details.Institute = System.Console.ReadLine();
                        repo.UpdateTrainer("Education_Details", "Institute", details.Institute, details.user_id);
                        return "TrainerUpdate";
                    case "16":
                        System.Console.Write("Enter your department: ");
                        details.Department = System.Console.ReadLine();
                        repo.UpdateTrainer("Education_Details", "Department", details.Department, details.user_id);
                        return "TrainerUpdate";
                    case "17":
                        System.Console.Write("Enter your start year: ");
                        details.Start_year = System.Console.ReadLine();
                        repo.UpdateTrainer("Education_Details", "Start_year", details.Start_year, details.user_id);
                        return "TrainerUpdate";
                    case "18":
                        System.Console.Write("Enter your End year: ");
                        details.End_year = System.Console.ReadLine();
                        repo.UpdateTrainer("Education_Details", "End_year", details.End_year, details.user_id);
                        return "TrainerUpdate";
                    default:
                        System.Console.WriteLine("------------------------------");
                        System.Console.WriteLine("Wrong choice, Try again!");
                        System.Console.WriteLine("Enter to continue");
                        System.Console.ReadLine();
                        return "TrainerUpdate";
                }
            }
            if(n == 2)
            {
                return "DeleteTrainerdetails";
            }
            if(n == 3)
            {
                return "DropTrainer";
            }
            if (n == 4)
            {
                Console.WriteLine("Logging Out......\n Hit Enter to Continue");
                Console.ReadLine();
                return "MainMenu";
            }
            return "ShowDetails";
        }
    }
}
