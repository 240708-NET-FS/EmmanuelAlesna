using System.Data;
using Project1.app.Repository.DAO;
using Project1.app.Repository.Entities;
using Project1.app.Utility;

namespace Project1.app.Service;

public class AccountService(AccountDAO accountDAO) : IService<Account>
{
    private readonly AccountDAO _accountDAO = accountDAO;
    public void CreateEntity(string[] details)
    {
        string username = details[0];
        string password = details[1];
        try
        {
            if (username.Length > 0 && password.Length > 0)
            {
                var existingUser = _accountDAO.GetByUsername(username);
                if (existingUser == null)
                {
                    _accountDAO.Create([username, password]);
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

    public void VerifiedDelete(string username, string password)
    {
        try
        {
            Account account = GetByUsername(username);
            if (Login(account.Username, password))
            {
                Delete(account);
                Console.WriteLine("Account deleted successfully.");
            }
            else
            {
                throw new InvalidDataException("Incorrect password. Returning to main menu.");
            }
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
        try
        {
            if (username.Length > 0 && password.Length > 0)
            {
                if (_accountDAO.GetByUsername(username) != null)
                {
                    var retrievedPassword = _accountDAO.Login(username);
                    if (retrievedPassword.Hash != null && retrievedPassword.Salt != null)
                    {
                        var result = PasswordUtilities.VerifyPassword(password, retrievedPassword.Hash, retrievedPassword.Salt);
                        if (result)
                        {
                            Console.WriteLine("Login successful!");
                            State.StateAccount = _accountDAO.GetByUsername(username);
                        }
                        else
                        {
                            throw new InvalidDataException("Incorrect password.");
                        }
                        return result;
                    }
                }
                else
                {
                    throw new InvalidDataException("That username does not exist.");
                }
            }
            else
            {
                throw new NoNullAllowedException("Username and/or password cannot be empty.");
            }
            return false;
        }
        catch (Exception e)
        {
            if (e is InvalidDataException || e is NoNullAllowedException)
            {
                Console.WriteLine(e);
            }
            return false;
        }
    }
}