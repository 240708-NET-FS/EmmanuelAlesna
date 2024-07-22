using Project1.app.Controller;
using Project1.app.Repository;
using Project1.app.Repository.DAO;
using Project1.app.Repository.Entities;
using Project1.app.Service;
using Project1.app.Utility;

namespace Project1.app;

class Program
{
    public static void Main(string[] args)
    {
        using var context = new ApplicationDbContext();
        // AccountDAO accountDAO = new(context);
        // PasswordDAO passwordDAO = new(context);

        // AccountService accountService = new(accountDAO);
        // PasswordService passwordService = new(passwordDAO);

        // AccountController accountController = new(accountService);
        MainController mainController = new(context);

        mainController.LoginStart();

        int? toNull = 3;
        Console.WriteLine(toNull + 3);
        /* using var context = new ApplicationDbContext();
        AccountDAO accountDAO = new(context);
        PasswordDAO passwordDAO = new(context);
        AccountService accountService = new(accountDAO);
        PasswordService passwordService = new(passwordDAO);

        // CREATE
        Account account1 = new()
        {
            Username = "emmanuelalesna6",
            Password = new Password() { Hash = PasswordUtilities.HashPassword("abc1234", out byte[] salt), Salt = salt }
        };
        accountService.CreateEntity(account1);
        
        // READ
        accountService.Login("emmanuelalesna", "abc1234");
        IEnumerable<Account> accounts = accountService.GetAll();
        // foreach (Account a in accounts)
        // {
        //     Console.WriteLine(a);
        // }

        // UPDATE
        account1.AAPL = 500;
        account1.AMZN = 1000;
        accountService.Update(account1);
        Console.WriteLine(accountService.GetByUsername("emmanuelalesna4"));

        // DELETE
        accountService.Delete(account1);
        accountService.GetByUsername("emmanuelalesna6"); */
    }
}