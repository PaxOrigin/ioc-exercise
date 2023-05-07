using IOCMainProgram.Services;
using IOCMainProgram.TestApp.ConsoleApp.MenuServices.MenuFunctions;

namespace IOCMainProgram.TestApp.ConsoleApp.MenuServices.ConcreteMenus;

public class LoginMenuService : ILoginMenuService
{

    private readonly IUserService _userService;

    private readonly IMenuElements _menuElements;

    private readonly IConsoleStringReader _consoleStringReader;

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string KeyDescription { get; private set; }

    public ConsoleKey? consoleKey { get; private set; }

    public LoginMenuService(IMenuElements menuElements, IUserService userService, IConsoleStringReader consoleStringReader)
    {
        KeyDescription = "2";
        consoleKey = ConsoleKey.D2;
        Description = "Log In";
        Name = "Log In";

        _menuElements = menuElements;
        _userService = userService;
        _consoleStringReader = consoleStringReader;
    }


    public void Run()
    {
        string? id;
        string? password;
        (bool, string) requestState = (true, string.Empty);

        do
        {
            Console.Clear();
            if (!requestState.Item1)
                _menuElements.PrintResultMessage(requestState.Item2);
            _menuElements.PrintMenuTitle(Name);
            Console.CursorVisible = true;
            id = _consoleStringReader.GetString("ID: ");
            password = _consoleStringReader.GetString("Password: ");
            Console.CursorVisible = false;
            requestState = _userService.LogIn(id, password);

        } while (!requestState.Item1);
    }

}
