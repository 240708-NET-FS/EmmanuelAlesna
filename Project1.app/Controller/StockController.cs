using Project1.app.Repository;
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
        3) View basic stats
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
                        Console.WriteLine($"AAPL: {State.StateAccount.AAPL}, MSFT: {State.StateAccount.MSFT}, NVDA: {State.StateAccount.NVDA}, GOOG: {State.StateAccount.GOOG}, AMZN: {State.StateAccount.AMZN}");
                        Console.WriteLine();
                        break;
                    case 2:
                        // change stocks
                        break;
                    case 3:
                        // view percentages
                        break;
                    case 4:
                        // create simple graph
                        break;
                    case 5:
                        // fund allocation calculation
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