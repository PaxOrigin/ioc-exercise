using DatabaseHandler.Models;

namespace IOCMainProgram.Services;

public interface IUserService
{
    public (bool, string) LogIn(string id, string password);

    public (bool, string) LogOut();

    public (bool, string) SignUp(string email, string password);

    public (bool, string) PrintCredential();

    public User? GetLoggedUser();
}
