using Microsoft.EntityFrameworkCore;
using Project1.app.Repository.Entities;
using Project1.app.Utility;

namespace Project1.app.Repository.DAO;

public class AccountDAO(ApplicationDbContext context) : IDAO<Account>
{
    private readonly ApplicationDbContext _context = context;

    public void Create(string[] details)
    {
        Account account = new()
        {
            Username = details[0],
            Password = new Password() { Hash = PasswordUtilities.HashPassword(details[1], out byte[] salt), Salt = salt }
        };
        _context.Add(account);
        _context.SaveChanges();
    }

    public void Delete(Account item)
    {
        _context.Accounts.Remove(item);
        _context.SaveChanges();
    }

    public ICollection<Account> GetAll()
    {
        return _context.Accounts.ToList();
    }

    public Account GetById(int id)
    {
        return _context.Accounts.FirstOrDefault(a => a.AccountID == id);
    }

    public Account GetByUsername(string username)
    {
        return _context.Accounts.FirstOrDefault(a => a.Username == username);
    }

    public void Update(Account newItem)
    {
        Account originalAccount = _context.Accounts.FirstOrDefault(a => a.AccountID == newItem.AccountID);
        if (originalAccount != null)
        {
            originalAccount.Username = newItem.Username;
            originalAccount.Password = newItem.Password;
            originalAccount.AAPL = newItem.AAPL;
            originalAccount.MSFT = newItem.MSFT;
            originalAccount.NVDA = newItem.NVDA;
            originalAccount.GOOG = newItem.GOOG;
            originalAccount.AMZN = newItem.AMZN;

            _context.Accounts.Update(originalAccount);
            _context.Passwords.Update(originalAccount.Password);
            _context.SaveChanges();
        }
    }

    public Password Login(string username)
    {
        Account account = GetByUsername(username);
        return _context.Passwords.Include(p => p.Account).FirstOrDefault(p => p.Account.AccountID == account.AccountID);
    }
}