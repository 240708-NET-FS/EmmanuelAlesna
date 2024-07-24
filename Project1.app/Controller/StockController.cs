using Project1.app.Repository;
using Project1.app.Service;
using Project1.app.Utility;

namespace Project1.app.Controller;

public class StockController(ApplicationDbContext context)
{
    public void StartStocks()
    {
        while (State.StateRunning)
        {
            Console.WriteLine($"Welcome, {State.StateAccount.Username}! Please select an option from those given below.");
            Console.WriteLine("""
        1) View your stocks
        2) Set stock values
        3) View stock percentages
        4) Create projection graphic
        5) View fund allocation tool
        6) Log out
        """);
            Console.Write("> ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                switch (result)
                {
                    case 1:
                        // view all stocks
                        StockService.ViewStocks();
                        break;
                    case 2:
                        // change stocks
                        StockService stockService = new(context);

                        Console.WriteLine("Enter the name of the stock you wish to change.");
                        Console.Write("> ");
                        var stockToChange = Console.ReadLine();

                        Console.WriteLine("Enter the new amount.");
                        Console.Write("> ");
                        var newAmount = Console.ReadLine();
                        stockService.ChangeStocks(stockToChange!, newAmount!);
                        break;
                    case 3:
                        // view percentages
                        StockService.ViewStockPercents();
                        break;
                    case 4:
                        // create simple graph
                        Console.WriteLine("Enter a stock name.");
                        Console.Write("> ");
                        var stock = Console.ReadLine();

                        Console.WriteLine("Enter a yearly percent yield, as an integer.");
                        Console.Write("> ");
                        var percentYield = Console.ReadLine();

                        Console.WriteLine("Enter a time duration, in years.");
                        Console.Write("> ");
                        var years = Console.ReadLine();

                        Console.WriteLine("Enter a file name. Please leave out the file extension.");
                        Console.Write("> ");
                        var fileName = Console.ReadLine();

                        StockService.CreateGraph(stock!, percentYield!, years!, fileName!);
                        break;
                    case 5:
                        // fund allocation calculation
                        Console.WriteLine("Enter the name of the stock you wish to calculate.");
                        Console.Write("> ");
                        var stockToCalc = Console.ReadLine();

                        Console.WriteLine("Enter the target percentage as a whole number.");
                        Console.Write("> ");
                        var target = Console.ReadLine();
                        StockService.TargetPercent(stockToCalc!, target!);
                        break;
                    case 6:
                        QuitController.Quit();
                        break;
                    default:
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