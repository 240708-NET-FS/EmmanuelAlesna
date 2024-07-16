using Project1.app.Repository.Entities;

namespace Project1.Tests;

public class AccountTests
{
  [Fact]
  public void InstantiateAccount()
  {
    Account account1 = new() { AccountUsername = "emmanuel", AccountPassword = "abc123", AccountID = 0 };
    Assert.IsType<Account>(account1);
  }
  [Fact]
  public void ShouldReturnCorrectUsername()
  {
    Account account2 = new() { AccountUsername = "emmanuel", AccountPassword = "abc123", AccountID = 0 };
    Assert.Equal("emmanuel", account2.AccountUsername);
  }
}