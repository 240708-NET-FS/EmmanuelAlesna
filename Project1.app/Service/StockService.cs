using System.Collections;
using Project1.app.Repository;
using Project1.app.Repository.DAO;
using Project1.app.Repository.Entities;
using Project1.app.Utility;

namespace Project1.app.Service;

public class StockService(ApplicationDbContext context)
{
    readonly AccountDAO accountDAO = new(context);
    public static void ViewStocks()
    {
        Console.WriteLine($"AAPL: {State.StateAccount.AAPL}, MSFT: {State.StateAccount.MSFT}, NVDA: {State.StateAccount.NVDA}, GOOG: {State.StateAccount.GOOG}, AMZN: {State.StateAccount.AMZN}");
        Console.WriteLine();
    }
    public void ChangeStocks()
    {
        AccountService accountService = new(accountDAO);
        Account account = State.StateAccount;

        Console.WriteLine("Enter the name of the stock you wish to change.");
        Console.Write("> ");
        string? stock = Console.ReadLine();

        Console.WriteLine("Enter the new amount.");
        Console.Write("> ");
        string? amount = Console.ReadLine();

        if (stock != null && amount != null)
        {
            if (int.TryParse(amount, out int result))
            {
                account.SetAsString(stock, result);
            }
            else
            {
                Console.WriteLine("Error: invalid number.");
            }
            accountService.Update(account);
            Console.WriteLine($"{stock} changed to {amount}.");
        }
        else
        {
            Console.WriteLine("Error: stock name and/or amount cannot be null.");
        }
    }
    public static void ViewStockPercents()
    {
        Console.WriteLine($"AAPL: {Math.Round(State.StateAccount.AAPL / State.StateAccount.GetTotal(), 4) * 100}%");
        Console.WriteLine($"MSFT: {Math.Round(State.StateAccount.MSFT / State.StateAccount.GetTotal(), 4) * 100}%");
        Console.WriteLine($"NVDA: {Math.Round(State.StateAccount.NVDA / State.StateAccount.GetTotal(), 4) * 100}%");
        Console.WriteLine($"GOOG: {Math.Round(State.StateAccount.GOOG / State.StateAccount.GetTotal(), 4) * 100}%");
        Console.WriteLine($"AMZN: {Math.Round(State.StateAccount.AMZN / State.StateAccount.GetTotal(), 4) * 100}%");
    }
    public static void CreateGraph()
    {
        Console.WriteLine("Enter a stock name.");
        Console.Write("> ");
        string? stock = Console.ReadLine();

        Console.WriteLine("Enter a yearly percent yield, as an integer.");
        Console.Write("> ");
        string? percentYield = Console.ReadLine();

        Console.WriteLine("Enter a time duration, in years.");
        Console.Write("> ");
        string? years = Console.ReadLine();

        if (stock != null && percentYield != null && years != null)
        {
            double stockValue = State.StateAccount.GetAsString(stock);
            if (int.TryParse(percentYield, out int percentInt) && int.TryParse(years, out int yearsInt))
            {
                ArrayList x = [];
                ArrayList y = [];
                for (int i = 0; i < yearsInt; i++)
                {
                    x.Add(DateTime.Now.Year + i);
                    y.Add(stockValue);
                    stockValue *= 1 + (percentInt / (double)100);
                }
                object[] xs = x.ToArray();
                object[] ys = y.ToArray();
                ScottPlot.Plot myPlot = new();
                myPlot.Add.Scatter(xs, ys);
                myPlot.SavePng("stock.png", 400, 300);
                Console.WriteLine("Graph saved!");
            }
        }
    }
    public static void TargetPercent()
    {
        Console.WriteLine("Enter the name of the stock you wish to calculate.");
        Console.Write("> ");
        string? stock = Console.ReadLine();

        Console.WriteLine("Enter the target percentage as a whole number.");
        Console.Write("> ");
        string? amount = Console.ReadLine();

        double heldAmount = State.StateAccount.GetAsString(stock!);
        if (int.TryParse(amount, out int result))
        {
            double res = ((result / (double)100 * State.StateAccount.GetTotal()) - heldAmount) / (1 - (result / (double)100));
            if (res > 0)
            {
                Console.WriteLine($"You need to add ${res} to reach {result}%.");
            }
            else if (res < 0)
            {
                Console.WriteLine($"You need to remove ${res} to reach {result}%.");
            }
            else
            {
                Console.WriteLine($"The chosen stock is already at {result}%.");
            }
        }
        else
        {
            Console.WriteLine("Error: invalid number.");
        }
    }
}