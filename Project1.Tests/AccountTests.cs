using Microsoft.EntityFrameworkCore;
using Project1.app.Repository;
using Project1.app.Repository.DAO;
using Project1.app.Repository.Entities;
using Project1.app.Service;
using Project1.app.Utility;

namespace Project1.Tests;

public class AccountTests
{

  static readonly ApplicationDbContext _context = new();
  static readonly AccountDAO accountDAO = new(_context);
  static readonly AccountService accountService = new(accountDAO);

  [Fact]
  public void ShouldReturnCorrectUsername()
  {
    Account account1 = new() { Username = "emmanuel", Password = new Password() { Hash = PasswordUtilities.HashPassword("abc123", out byte[] salt), Salt = salt } };
    accountService.CreateEntity(account1);

    var account = accountService.GetByUsername("emmanuel");

    Assert.Equal("emmanuel", account.Username);
    accountService.Delete(account1);
  }

  [Fact]
  public void ShouldVerifyCorrectPassword()
  {
    Account account1 = new() { Username = "emmanuel", Password = new Password() { Hash = PasswordUtilities.HashPassword("abc123", out byte[] salt), Salt = salt } };
    accountService.CreateEntity(account1);

    var passResult = accountService.Login("emmanuel", "abc123");
    var failResult = accountService.Login("emmanuel", "abcd123");

    Assert.True(passResult);
    Assert.False(failResult);

    accountService.Delete(account1);
  }

  [Fact]
  public void ShouldUpdateAAPL()
  {
    // Given
    Account oldAccount = new() { Username = "old", Password = new Password() { Hash = PasswordUtilities.HashPassword("abc123", out byte[] salt), Salt = salt } };
    accountService.CreateEntity(oldAccount);
    Account newAccount = oldAccount;
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
    Account toDelete = new() { Username = "old", Password = new Password() { Hash = PasswordUtilities.HashPassword("abc123", out byte[] salt), Salt = salt } };
    accountService.CreateEntity(toDelete);
    // When
    accountService.Delete(toDelete);
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