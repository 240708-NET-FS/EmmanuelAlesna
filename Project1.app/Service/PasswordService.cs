using Project1.app.Repository.DAO;
using Project1.app.Repository.Entities;

namespace Project1.app.Service;

public class PasswordService(PasswordDAO passwordDAO) : IService<Password>
{
    private readonly PasswordDAO _passwordDAO = passwordDAO;

    public void CreateEntity(Password item)
    {
        _passwordDAO.Create(item);
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