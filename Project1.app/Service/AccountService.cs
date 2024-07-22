using System.Data;
using Project1.app.Repository.DAO;
using Project1.app.Repository.Entities;
using Project1.app.Utility;

namespace Project1.app.Service;

public class AccountService(AccountDAO accountDAO) : IService<Account>
{
    private readonly AccountDAO _accountDAO = accountDAO;

    public void CreateEntity(Account item)
    {
        try
        {
            if (item.Username != null && item.Password != null)
            {
                var existingUser = _accountDAO.GetByUsername(item.Username);
                if (existingUser == null)
                {
                    _accountDAO.Create(item);
                    Console.WriteLine("Account saved successfully!");
                }
                else
                {
                    throw new InvalidDataException("An account with that username already exists.");
                }
            }
            else
            {
                throw new NoNullAllowedException("Username and/or password cannot be null.");
            }
        }
        catch (Exception e)
        {
            if (e is InvalidDataException || e is NoNullAllowedException)
            {
                Console.WriteLine(e);
            }
            throw;
        }
    }

    public void Delete(Account item)
    {
        try
        {
            _accountDAO.Delete(item);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public ICollection<Account> GetAll()
    {
        ICollection<Account> output;
        try
        {
            output = _accountDAO.GetAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return output;
    }

    public Account GetById(int id)
    {
        Account output;
        try
        {
            output = _accountDAO.GetById(id);
            if (output == null)
            {
                throw new InvalidDataException("No account with that ID exists.");
            }
        }
        catch (InvalidDataException e)
        {
            Console.WriteLine(e);
            throw;
        }
        return output;
    }

    public Account GetByUsername(string username)
    {
        Account output;
        try
        {
            output = _accountDAO.GetByUsername(username);
            if (output == null)
            {
                throw new InvalidDataException("No account with that username exists.");
            }
        }
        catch (InvalidDataException e)
        {
            Console.WriteLine(e);
            throw;
        }
        return output;
    }

    public void Update(Account item)
    {
        try
        {
            if (item.Username != null && item.Password != null)
            {
                _accountDAO.Update(item);
            }
            else
            {
                throw new NoNullAllowedException("Username and/or password cannot be null.");
            }
        }
        catch (NoNullAllowedException e)
        {
            Console.WriteLine(e);
        }
    }

    public bool Login(string username, string password)
    {
        if (username.Length > 0 && password.Length > 0)
        {
            if (_accountDAO.GetByUsername(username) != null)
            {
                var retrievedPassword = _accountDAO.Login(username);
                var result = PasswordUtilities.VerifyPassword(password, retrievedPassword.Hash, retrievedPassword.Salt);
                if (result)
                {
                    Console.WriteLine("Login successful!");
                    State.StateAccount = _accountDAO.GetByUsername(username);
                }
                else
                {
                    Console.WriteLine("Error: incorrect password.");
                }
                return result;
            }
            else
            {
                Console.WriteLine("Error: that username does not exist.");
            }
        }
        else
        {
            Console.WriteLine("Error: username and/or password cannot be empty.");
        }
        return false;
    }
}