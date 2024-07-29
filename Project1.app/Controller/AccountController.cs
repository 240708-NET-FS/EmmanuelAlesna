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
        accountService.CreateEntity([username!, password!]);
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
    public void Delete()
    {
        Console.WriteLine("Please enter the details of the account to delete.");
        Console.Write("Username: ");
        var username = Console.ReadLine();
        Console.Write("Password: ");
        var password = Console.ReadLine();
        accountService.VerifiedDelete(username!, password!);
    }
}