using Project1.app.Repository.Entities;
using Project1.app.Service;
using Project1.app.Utility;

namespace Project1.app.Controller;

public class AccountController(AccountService service)
{
    private readonly AccountService accountService = service;

    public void Create()
    {
        Console.WriteLine("""
        Please enter a username and password.
        """);
        Console.Write("Username: ");
        var username = Console.ReadLine();
        Console.Write("Password: ");
        var password = Console.ReadLine();
        if (password != null && password.Length > 0)
        {
            Account account1 = new()
            {
                Username = username,
                Password = new Password() { Hash = PasswordUtilities.HashPassword(password, out byte[] salt), Salt = salt }
            };
            accountService.CreateEntity(account1);
        }
        else
        {
            Console.WriteLine("Error: password cannot be null.");
        }

    }
    public void Login()
    {
        Console.WriteLine("Please enter your username and password.");
        Console.Write("Username: ");
        var username = Console.ReadLine();
        Console.Write("Password: ");
        var password = Console.ReadLine();
        accountService.Login(username!, password!);
    }
}