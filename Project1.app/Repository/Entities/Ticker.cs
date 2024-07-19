namespace Project1.app.Repository.Entities;

public class Ticker(string symbol, double amount)
{
    public string Symbol { get; set; } = symbol;
    public double Amount { get; set; } = amount;
}