namespace Project1.app.Repository.Entities;
public class Account
{
    public int AccountID { get; set; }
    public string Username { get; set; }
    public Password? Password { get; set; }
    public double AAPL { get; set; } = 0;
    public double MSFT { get; set; } = 0;
    public double NVDA { get; set; } = 0;
    public double GOOG { get; set; } = 0;
    public double AMZN { get; set; } = 0;

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
        try
        {
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
        catch (InvalidDataException e)
        {
            Console.WriteLine(e);
        }
    }

    public override string ToString()
    {
        return $"{AccountID}, {Username}, {AAPL}, {MSFT}, {NVDA}, {GOOG}, {AMZN}";
    }
}