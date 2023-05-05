namespace DatabaseHandler.Repositories;

using DatabaseHandler.Models;

public interface IUserRepository
{
    public void AddUser(User user);

    public bool CheckExistance(string email);

    public int RetrieveID(User user);

    public User? RetrieveUser(int ID);
}
