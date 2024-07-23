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

    public double GetTotal()
    {
        return AAPL + MSFT + NVDA + GOOG + AMZN;
    }

    public double GetAsString(string input)
    {
        input = input.ToUpper();
        return input switch
        {
            "AAPL" => AAPL,
            "MSFT" => MSFT,
            "NVDA" => NVDA,
            "GOOG" => GOOG,
            "AMZN" => AMZN,
            _ => throw new InvalidDataException("Error: incorrect stock name."),
        };
    }
    public void SetAsString(string input, double newValue)
    {
        input = input.ToUpper();
        switch (input)
        {
            case "AAPL":
                AAPL = newValue;
                break;
            case "MSFT":
                MSFT = newValue;
                break;
            case "NVDA":
                NVDA = newValue;
                break;
            case "GOOG":
                GOOG = newValue;
                break;
            case "AMZN":
                AMZN = newValue;
                break;
            default:
                throw new InvalidDataException("Error: incorrect stock name.");
        }
    }

    public override string ToString()
    {
        return $"{AccountID}, {Username}, {AAPL}, {MSFT}, {NVDA}, {GOOG}, {AMZN}";
    }
}