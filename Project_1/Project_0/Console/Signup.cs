using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TrainersData;

namespace Console
{
    internal class SignUp : IAlldetails
    {
        internal static Details details = new Details();

        public SignUp(Details trainer)
        {
            details = trainer;
        }
        public SignUp()
        {

        }

        static string conStr = File.ReadAllText("../../../../Data/connectionString.txt");

        IData repo = new SqlRepo(conStr);

        public void Display()
        {
            System.Console.WriteLine("\n-------TRAINER DETAILS-------\n");
            System.Console.WriteLine("[0] Menu");
            System.Console.WriteLine("[1] Save");
            System.Console.WriteLine("[2] Email            : " + details.Email);
            System.Console.WriteLine("[3] Password         : " + details.Password);
            System.Console.WriteLine("[4] Fullname         : " + details.Full_name);
            System.Console.WriteLine("[5] Age              : " + details.Age);
            System.Console.WriteLine("[6] Gender           : " + details.Gender);
            System.Console.WriteLine("[7] Phone number     : " + details.Mobile_Number);
            System.Console.WriteLine("[8] Website          : " + details.Website);
            System.Console.WriteLine("[9] Skill name       : " + details.Skill_Name);
            System.Console.WriteLine("[10]Skill Type       : " + details.Skill_Type);
            System.Console.WriteLine("[11]Skill Level      : " + details.Skill_Level);
            System.Console.WriteLine("[12]Company_name     : " + details.Company_name);
            System.Console.WriteLine("[13] Company_Type    : " + details.Company_type);
            System.Console.WriteLine("[14] Experience      : " + details.Experience);
            System.Console.WriteLine("[15]Company_Desc     : " + details.Company_Description);
            System.Console.WriteLine("[16]Highest Qualification : " + details.Highest_Graduation);
            System.Console.WriteLine("[17] Institute           : " + details.Institute);
            System.Console.WriteLine("[18] Department          : " + details.Department);
            System.Console.WriteLine("[19] Start Year           : " + details.Start_year);
            System.Console.WriteLine("[20] End Year             : " + details.End_year);
        }
        public string UserChoice()
        {
            System.Console.WriteLine("--------------------------");
            System.Console.Write("\nEnter your choice: ");
            string userchoice = System.Console.ReadLine();

            switch (userchoice)
            {
                case "0":
                    return "AddTrainer";
                case "1":
                    try
                    {
                        Log.Logger.Information("Adding trainer details");
                        repo.Add(details);
                        details = new Details();
                        Log.Logger.Information("Successfully added trainer details");
                    }
                    catch (System.Exception ex)
                    {
                        Log.Logger.Information($"Failed to add trainer details {ex.Message}");
                        System.Console.WriteLine("Press Enter to continue");
                        System.Console.ReadLine();
                    }
                    return "AddTrainer";
                case "2":
                    System.Console.Write("Enter your Email ID: ");
                    details.Email = System.Console.ReadLine();
                    return "Signup";
                case "3":
                    System.Console.Write("Enter your Password: ");
                    details.Password = System.Console.ReadLine();
                    return "Signup";
                case "4":
                    System.Console.Write("Enter your Fullname: ");
                    details.Full_name = System.Console.ReadLine();
                    return "Signup";
                case "5":
                    try
                    {
                        System.Console.Write("Enter your Age: ");
                        details.Age = Convert.ToInt32(System.Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Age should be in numbers!!");
                        System.Console.WriteLine(ex.Message);
                        System.Console.ReadLine();
                    }
                    return "Signup";
                case "6":
                    System.Console.Write("Enter your Gender: ");
                    details.Gender = System.Console.ReadLine();
                    return "Signup";

                case "7":
                    System.Console.Write("Enter your Mobile number: ");
                    string pattern = @"\(?\d{3}\)?(-|.|\s)?\d{3}(-|.)?\d{4}";

                    string phone_number = System.Console.ReadLine();

                    if (Regex.IsMatch(phone_number, pattern))
                    {
                        details.Mobile_Number = phone_number;
                    }
                    else
                    {
                        System.Console.WriteLine("Wrong pattern try again...");
                        System.Console.ReadLine();
                    }
                    return "Signup";

                case "8":
                    System.Console.Write("Enter you Website: ");
                    details.Website = System.Console.ReadLine();
                    return "Signup";

                case "9":
                    System.Console.Write("Enter your Skill name: ");
                    details.Skill_Name = System.Console.ReadLine();
                    return "Signup";

                case "10":
                    System.Console.Write("Enter your Skill type: ");
                    details.Skill_Type = System.Console.ReadLine();
                    return "Signup";

                case "11":
                    System.Console.Write("Enter your Skill level: ");
                    details.Skill_Level = System.Console.ReadLine();
                    return "Signup";
                case "12":
                    System.Console.Write("Enter your Company name: ");
                    details.Company_name = System.Console.ReadLine();
                    return "Signup";
                case "13":
                    System.Console.Write("Enter your Company type: ");
                    details.Company_type = System.Console.ReadLine();
                    return "Signup";
                case "14":
                    System.Console.Write("Enter your Experience: ");
                    details.Experience = System.Console.ReadLine();
                    return "Signup";
                case "15":
                    System.Console.Write("Enter your Company description: ");
                    details.Company_Description = System.Console.ReadLine();
                    return "Signup";
                case "16":
                    System.Console.Write("Enter your Highest Qualification: ");
                    details.Highest_Graduation = System.Console.ReadLine();
                    return "Signup";
                case "17":
                    System.Console.Write("Enter your Institute: ");
                    details.Institute = System.Console.ReadLine();
                    return "Signup";
                case "18":
                    System.Console.Write("Enter your department: ");
                    details.Department = System.Console.ReadLine();
                    return "Signup";
                case "19":
                    System.Console.Write("Enter your start year: ");
                    details.Start_year = System.Console.ReadLine();
                    return "Signup";
                case "20":
                    System.Console.Write("Enter your End year: ");
                    details.End_year = System.Console.ReadLine();
                    return "Signup";
            }
        }
    }
}
