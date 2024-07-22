using Project1.app.Repository.Entities;
using Project1.app.Utility;

namespace Project1.Tests;

public class AccountTests
{
  [Fact]
  public void InstantiateAccount()
  {
    Account account1 = new() { Username = "emmanuel", Password = new Password() { Hash = PasswordUtilities.HashPassword("abc123", out byte[] salt), Salt = salt } };

    Assert.IsType<Account>(account1);
  }
  [Fact]
  public void ShouldReturnCorrectUsername()
  {
    Account account2 = new() { Username = "emmanuel", Password = new Password() { Hash = PasswordUtilities.HashPassword("abc123", out byte[] salt), Salt = salt } };
    Assert.Equal("emmanuel", account2.Username);
  }
}