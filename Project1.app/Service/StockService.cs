using System.Collections;
using System.Data;
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
        Console.WriteLine($"""
        AAPL: {State.StateAccount.AAPL}
        MSFT: {State.StateAccount.MSFT}
        NVDA: {State.StateAccount.NVDA}
        GOOG: {State.StateAccount.GOOG}
        AMZN: {State.StateAccount.AMZN}

        """);
    }
    public void ChangeStocks(string stock, string amount)
    {
        try
        {
            AccountService accountService = new(accountDAO);
            Account account = State.StateAccount;

            if (stock != null && amount != null)
            {
                if (int.TryParse(amount, out int result) && result > 0)
                {
                    account.SetAsString(stock, result);
                    accountService.Update(account);
                    Console.WriteLine($"{stock} changed to {amount}.");
                }
                else
                {
                    throw new InvalidDataException("Invalid number.");
                }
            }
            else
            {
                throw new NoNullAllowedException("Stock name and/or amount cannot be null.");
            }
        }
        catch (Exception e)
        {
            if (e is InvalidDataException || e is NoNullAllowedException)
            {
                Console.WriteLine(e);
            }
        }
    }
    public static void ViewStockPercents()
    {
        Console.WriteLine($"""
        AAPL: {Math.Round(State.StateAccount.AAPL / State.StateAccount.GetTotal(), 4) * 100}%
        MSFT: {Math.Round(State.StateAccount.MSFT / State.StateAccount.GetTotal(), 4) * 100}%
        NVDA: {Math.Round(State.StateAccount.NVDA / State.StateAccount.GetTotal(), 4) * 100}%
        GOOG: {Math.Round(State.StateAccount.GOOG / State.StateAccount.GetTotal(), 4) * 100}%
        AMZN: {Math.Round(State.StateAccount.AMZN / State.StateAccount.GetTotal(), 4) * 100}%

        """);
    }
    public static void CreateGraph(string stock, string percentYield, string years, string fileName)
    {
        try
        {
            if (stock.Length > 0 && percentYield.Length > 0 && years.Length > 0 && fileName.Length > 0)
            {
                double stockValue;
                try
                {
                    stockValue = State.StateAccount.GetAsString(stock);
                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e);
                    return;
                }
                if (int.TryParse(percentYield, out int percentInt) && int.TryParse(years, out int yearsInt) && yearsInt > 0)
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
                    myPlot.SavePng(fileName + ".png", 400, 300);
                    Console.WriteLine("Graph saved!");
                    Console.WriteLine();
                }
                else
                {
                    throw new InvalidDataException("Invalid numbers.");
                }
            }
            else
            {
                throw new NoNullAllowedException("Inputs cannot be null.");
            }
        }
        catch (Exception e)
        {
            if (e is InvalidDataException || e is NoNullAllowedException)
            {
                Console.WriteLine(e);
            }
        }
    }
    public static void TargetPercent(string stock, string amount)
    {
        try
        {
            if (stock != null && amount != null)
            {
                double heldAmount;
                try
                {
                    heldAmount = State.StateAccount.GetAsString(stock!);
                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e);
                    return;
                }
                if (int.TryParse(amount, out int result) && result >= 0 && result <= 100)
                {
                    double res = ((result / (double)100 * State.StateAccount.GetTotal()) - heldAmount) / (1 - (result / (double)100));
                    if (res > 0)
                    {
                        Console.WriteLine($"You need to buy ${res} to reach {result}%.");
                    }
                    else if (res < 0)
                    {
                        Console.WriteLine($"You need to sell ${res} to reach {result}%.");
                    }
                    else
                    {
                        Console.WriteLine($"The chosen stock is already at {result}%.");
                    }
                }
                else
                {
                    throw new InvalidDataException("Invalid number.");
                }
            }
            else
            {
                throw new NoNullAllowedException("Stock name and/or amount cannot be null.");
            }
        }
        catch (Exception e)
        {
            if (e is InvalidDataException || e is NoNullAllowedException)
            {
                Console.WriteLine(e);
            }
        }
    }
}