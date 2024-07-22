using Project1.app.Repository;
using Project1.app.Repository.DAO;
using Project1.app.Repository.Entities;
using Project1.app.Service;
using Project1.app.Utility;

namespace Project1.app.Controller;

class MainController(ApplicationDbContext context)
{
    readonly AccountDAO accountDAO = new(context);
    public void LoginStart()
    {
        while (State.StateRunning)
        {
            if (State.StateAccount.Username != null)
            {
                StockController stockController = new(context);
                stockController.StartStocks();
            }
            AccountService accountService = new(accountDAO);
            Console.WriteLine("""
        Welcome to my investment portfolio app! Please select an option from those given below.
        1) Create account
        2) Login
        3) Quit
        """
            );
            Console.Write("> ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                AccountController accountController = new(accountService);
                switch (result)
                {
                    case 1:
                        accountController.Create();
                        break;
                    case 2:
                        accountController.Login();
                        break;
                    case 3:
                        QuitController.Quit();
                        break;
                    default:
                        Console.WriteLine("Error: invalid input.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error: please enter a valid number.");
            }
        }

    }
}