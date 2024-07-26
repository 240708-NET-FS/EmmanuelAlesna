using Microsoft.EntityFrameworkCore;
using Project1.app.Repository.Entities;

namespace Project1.app.Repository.DAO;

public class PasswordDAO(ApplicationDbContext context) : IDAO<Password>
{
    private readonly ApplicationDbContext _context = context;

    public void Create(Password item)
    {
        _context.Add(item);
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