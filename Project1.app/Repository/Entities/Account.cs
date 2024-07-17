namespace Project1.app.Repository.Entities;
public class Account
{
  public int AccountID { get; set; }
  public string AccountUsername { get; set; }
  public string AccountPassword { get; set; }
  public ICollection<Order> Orders { get; set; }

  // private double AccountBalance = 0;

  // public string Password
  // {
  //   get
  //   {
  //     return Password;
  //   }
  //   set
  //   {
  //     Password = Passwords.HashPassword(value, out byte[] salt);
  //   }
  // }
  // public double Balance
  // {
  //   get
  //   {
  //     Console.WriteLine($"Your total balance is {AccountBalance}.");
  //     return AccountBalance;
  //   }
  //   set
  //   {
  //     AccountBalance = value;
  //   }
  // }
}