global using Serilog;
using TrainersData;
using System;
using System.Data.SqlClient;
using Models;

namespace Console1
{
    internal class Program : SignUp
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(@"..\..\..\Logs\logs.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
                .CreateLogger();

            Log.Logger.Information("-------Program starts-------");

            bool value = true;
            bool value2;

            IAlldetails menu = new Alldetails();

            while (value)
            {
                System.Console.Clear();
                menu.Display();

                string reply = menu.UserChoice();

                switch (reply)
                {
                    case "GetAllTrainers":
                        menu = new GetAllTrainers();
                        break;
                    case "Menu":
                        menu = new Alldetails();
                        break;
                    case "Signup":
                        menu = new SignUp();
                        break;
                    case "AddTrainer":
                        Log.Logger.Information("User select trainer Add trainer");
                        menu = new AddTrainer();
                        break;
                    case "ShowDetails":
                        Log.Logger.Information("user select showing details");
                        menu = new TrainerUpdate();
                        break;
                    case "SearchTrainer":
                        Log.Logger.Information("User select Search Trainer");
                        menu = new SearchTraineer();
                        break;

                    case "Login":
                        Log.Logger.Information("User select trainer");
                        details = new Details();
                        menu = new Login();

                        value2 = true;

                        while (value2)
                        {
                            System.Console.Clear();
                            menu.Display();
                            string Choice = menu.UserChoice();

                            switch (Choice)
                            {
                                case "TrainerUpdate":
                                    //System.Console.WriteLine("You must need to login to update");
                                    Log.Logger.Information("user select update trainer");
                                    menu = new TrainerUpdate();
                                    break;
                                case "SearchTrainer":
                                    Log.Logger.Information("user select showing details");
                                    menu = new SearchTraineer();
                                    break;
                                case "DeleteTrainerdetails":
                                    Log.Logger.Information("User Select Delete Trainer");
                                    menu = new DeleteTrainers(details);
                                    break;
                                case "DropTrainer":
                                    Log.Logger.Information("user select Drop");
                                    menu = new dropTrainer();
                                    break;
                                case "Menu":
                                    Log.Logger.Information("User select Main menu");
                                    menu = new Alldetails();
                                    value2 = false;
                                    break;
                                case "ShowDetails":
                                    Log.Logger.Information("user select showing details");
                                    menu = new UserInteraction(details);
                                    break;
                                case "Exit":
                                    Log.Logger.Information("To exit");
                                    menu = new AddTrainer();
                                    break;
                                default:
                                    System.Console.WriteLine("Wrong Choice... Try again...");
                                    System.Console.WriteLine("Enter to Continue...");
                                    System.Console.ReadLine();
                                    break;
                            }
                        }
                        break;

                    case "Exit":
                        System.Console.WriteLine("------Thank You :)---------");
                        System.Console.WriteLine("Exiting...");
                        Log.Logger.Information("-------Program ends-------");
                        Log.CloseAndFlush();
                        value = false;
                        break;

                    default:
                        System.Console.WriteLine("DataBase not exist");
                        System.Console.WriteLine("Press Enter to continue...");
                        System.Console.ReadLine();
                        break;
                }
            }
        }
    }
}