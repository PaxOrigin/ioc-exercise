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
        _credentialDBContext.Users.Add(user);
        _credentialDBContext.SaveChanges();
    }

    public bool CheckExistance(string email)
        => _credentialDBContext.Users.Any(p => p.Email == email);

    public int RetrieveID(User user)
        => _credentialDBContext.Users.First(p => p.Email == user.Email).Id;

    public User? RetrieveUser(int ID)
    {
        return _credentialDBContext.Users.FirstOrDefault(p => p.Id == ID);
    }

}
