using Microsoft.EntityFrameworkCore;
using Project1.app.Repository.Entities;
using Project1.app.Utility;

namespace Project1.app.Repository.DAO;

public class PasswordDAO(ApplicationDbContext context) : IDAO<Password>
{
    private readonly ApplicationDbContext _context = context;

    public void Create(string[] details)
    {
        Password password = new() { Hash = PasswordUtilities.HashPassword(details[0], out byte[] salt), Salt = salt };
        _context.Add(password);
        _context.SaveChanges();
    }

    public void Delete(Password item)
    {
        _context.Passwords.Remove(item);
        _context.SaveChanges();
    }

    public ICollection<Password> GetAll()
    {
        return _context.Passwords.ToList();
    }

    public Password GetById(int id)
    {
        return _context.Passwords.Include(p => p.Account).FirstOrDefault(p => p.PasswordID == id);
    }

    public void Update(Password newItem)
    {
    }
}