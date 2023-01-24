
using System;
using Console1;
using TrainersData;

public class Login : IAlldetails
{
    static string conStr = File.ReadAllText("../../../connectionString.txt");

    IData repo = new SqlRepo(conStr);
    public void Display()
    {
        System.Console.WriteLine("-------LOGIN PAGE------");
        System.Console.WriteLine("[0] for Trainer Menu");
        System.Console.WriteLine("[1] to proceed Login");
    }

    public string UserChoice()
    {
        
        System.Console.Write("Enter your choice: ");
        string userChoice = System.Console.ReadLine();

        switch (userChoice)
        {
            case "0":
                return "Menu";
            case "1":
                System.Console.Write("Enter your Email ID: ");
                string Email = System.Console.ReadLine();
                bool ans = repo.login(Email);
                if (ans)
                {
                    SignUp TrainerLogin = new SignUp(repo.GetAllTrainer(Email));
                    TrainerUpdate up = new TrainerUpdate();
                    return "TrainerUpdate";
                }
                else
                {
                    System.Console.WriteLine("Account not found");
                    System.Console.ReadLine();
                    return "Login";
                }

            default:
                System.Console.WriteLine("Wrong choice try again...");
                System.Console.WriteLine("Press Enter to continue...");
                System.Console.ReadLine();
                return "Login";
        }
    }
}