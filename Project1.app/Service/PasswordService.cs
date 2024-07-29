using System.Data;
using Project1.app.Repository.DAO;
using Project1.app.Repository.Entities;
using Project1.app.Utility;

namespace Project1.app.Service;

public class PasswordService(PasswordDAO passwordDAO) : IService<Password>
{
    private readonly PasswordDAO _passwordDAO = passwordDAO;

    public void CreateEntity(string[] details)
    {
        try
        {
            if (details[0].Length > 0)
            {
                _passwordDAO.Create(details);
            }
            else
            {
                throw new NoNullAllowedException("Password cannot be null.");
            }
        }
        catch (NoNullAllowedException e)
        {
            Console.WriteLine(e);
        }
    }

    public void Delete(Password item)
    {
        _passwordDAO.Delete(item);
    }

    public ICollection<Password> GetAll()
    {
        throw new NotImplementedException();
    }

    public Password GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Password item)
    {
        throw new NotImplementedException();
    }
}