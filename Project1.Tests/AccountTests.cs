using Project1.app.Repository;
using Project1.app.Repository.DAO;
using Project1.app.Repository.Entities;
using Project1.app.Service;

namespace Project1.Tests;

public class AccountTests
{
  static readonly ApplicationDbContext _context = new();
  static readonly AccountDAO accountDAO = new(_context);
  static readonly AccountService accountService = new(accountDAO);

  [Fact]
  public void ShouldReturnCorrectUsername()
  {
    accountService.CreateEntity(["emmanuel", "abc123"]);

    var account = accountService.GetByUsername("emmanuel");

    Assert.Equal("emmanuel", account.Username);
    accountService.VerifiedDelete("emmanuel", "abc123");
  }

  [Fact]
  public void ShouldVerifyCorrectPassword()
  {
    // arrange
    accountService.CreateEntity(["emmanuel", "abc123"]);
    // act
    var passResult = accountService.Login("emmanuel", "abc123");
    var failResult = accountService.Login("emmanuel", "abcd123");
    // assert
    Assert.True(passResult);
    Assert.False(failResult);

    accountService.VerifiedDelete("emmanuel", "abc123");
  }

  [Fact]
  public void ShouldUpdateAAPL()
  {
    // Given
    accountService.CreateEntity(["old", "abc123"]);
    Account newAccount = accountService.GetByUsername("old");
    newAccount.AAPL = 10000;
    // When
    accountService.Update(newAccount);
    var result = accountService.GetById(newAccount.AccountID);
    // Then
    Assert.Equal(10000, result.AAPL);

    accountService.Delete(newAccount);
  }

  [Fact]
  public void ShouldDelete()
  {
    // Given
    accountService.CreateEntity(["old", "abc123"]);
    // When
    accountService.VerifiedDelete("old", "abc123");
    // Then
    try
    {
      accountService.GetByUsername("old");
    }
    catch (InvalidDataException e)
    {
      Assert.IsType<InvalidDataException>(e);
    }
  }
}