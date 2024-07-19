using Microsoft.IdentityModel.Tokens;
using Project1.app.Repository.DAO;
using Project1.app.Service;

namespace Project1.app.Controller;

public class AccountController(AccountService accountService)
{
    private AccountService accountService = accountService;
    public void Login()
    {
        Console.Write("Username: ");
        string username = Console.ReadLine();

        Console.Write("Password:");
        string password = Console.ReadLine();
    }
}