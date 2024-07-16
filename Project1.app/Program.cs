using Project1.app.Repository;
using Project1.app.Repository.Entities;

namespace Project1.app;

class Program
{
    public static void Main(string[] args)
    {
        using var context = new ApplicationDbContext();
        var account = new Account { AccountUsername = "emmanuelalesna", AccountPassword = "abc123", AccountID = 0 };
        context.Accounts.Add(account);
        context.SaveChanges();
    }
}