namespace DatabaseHandler.Repositories;

using DatabaseHandler.Models;

public class UserRepository : IUserRepository
{
    private readonly CredentialDBContext _credentialDBContext;
    public UserRepository(CredentialDBContext credentialDBContext)
    {
        _credentialDBContext = credentialDBContext;
    }

    public void AddUser(User user)
    {
        try
        {
            _credentialDBContext.Users.Add(user);
            _credentialDBContext.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"The addition of {user.Email} to the Database failed.");
            Console.Error.WriteLine(ex.Message);
        }
    }

    public bool CheckExistance(string email)
        => _credentialDBContext.Users.Any(p => p.Email == email);

    public int RetrieveID(User user)
        => _credentialDBContext.Users.First(p => p.Email == user.Email).Id;

    public User? RetrieveUser(int ID)
    {
        try
        {
            return _credentialDBContext.Users.First(p => p.Id == ID);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Failed To Retrieve User");
            Console.Error.WriteLine(ex.Message);
            return null;
        }

    }

}
