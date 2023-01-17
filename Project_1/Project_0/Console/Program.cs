global using Serilog;
using TrainersData;
using System;
using System.Data.SqlClient;

namespace Console
{
    internal class Program : SignUp
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(@"..\..\..\..\Logs\logs.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
                .CreateLogger();

            Log.Logger.Information("-------Program starts-------");

            bool value = true;
            bool value2 = true;

            IAlldetails menu = new Alldetails();

            while (value)
            {
                System.Console.Clear();
                menu.Display();

                string reply = menu.UserChoice();

                switch (reply)
                {
                    case "Menu":
                        Log.Logger.Information("Display menu to the user");
                        menu = new Alldetails();
                        break;

                    case "GetTrainers":
                        menu = new GetAllTrainers();
                        break;

                    case "AddTrainer":

                        Log.Logger.Information("User select trainer");
                        value2 = true;

                        menu = new AddTrainer();

                        while (value2)
                        {
                            System.Console.Clear();
                            menu.Display();
                            string Choice = menu.UserChoice();

                            switch (Choice)
                            {
                                case "Login":
                                    Log.Logger.Information("User select trainer login");
                                    menu = new Login();
                                    break;
                                case "Signup":
                                    Log.Logger.Information("User select trainer signup");
                                    menu = new SignUp();
                                    break;
                                case "MainMenu":
                                    Log.Logger.Information("User select Main menu");
                                    menu = new Alldetails();
                                    value2 = false;
                                    break;
                                case "Exit":
                                    Log.Logger.Information("To exit");
                                    menu = new AddTrainer();
                                    break;
                                default:
                                    System.Console.WriteLine("Wrong Choice! Try again...");
                                    System.Console.WriteLine("Enter to Continue...");
                                    System.Console.ReadLine();
                                    break;
                            }
                        }
                        break;

                    case "Exit":
                        System.Console.WriteLine("Exiting...");
                        Log.Logger.Information("-------Program ends-------");
                        Log.CloseAndFlush();
                        value = false;
                        break;

                    default:
                        System.Console.WriteLine("DataBase Does not exist");
                        System.Console.WriteLine("Press Enter to continue...");
                        System.Console.ReadLine();
                        break;
                }
            }
        }
    }
}