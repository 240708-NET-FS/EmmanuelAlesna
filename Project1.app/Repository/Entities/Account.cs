namespace Project1.app.Repository.Entities;
public class Account
{
    public int AccountID { get; set; }
    public string Username { get; set; }
    public Password Password { get; set; }
    // public ICollection<Ticker> doubles { get; set; }
    public double AAPL { get; set; }
    public double MSFT { get; set; }
    public double NVDA { get; set; }
    public double GOOG { get; set; }
    public double AMZN { get; set; }
    public override string ToString()
    {
        return $"{AccountID}, {Username}, {AAPL}, {MSFT}, {NVDA}, {GOOG}, {AMZN}";
    }
}