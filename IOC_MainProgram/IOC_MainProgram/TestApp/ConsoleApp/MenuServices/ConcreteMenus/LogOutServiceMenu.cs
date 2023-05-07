using IOCMainProgram.Services;
using IOCMainProgram.TestApp.ConsoleApp.MenuServices.MenuFunctions;

namespace IOCMainProgram.TestApp.ConsoleApp.MenuServices.ConcreteMenus;

public class LogOutServiceMenu : ILogoutServiceMenu
{
    public string Name { get; private set; }

    public string Description { get; private set; }

    public string KeyDescription { get; private set; }

    public ConsoleKey? consoleKey { get; private set; }

    private const int _distantiator = 22;

    private readonly IUserService _userService;

    private readonly IMenuElements _menuElements;

    public LogOutServiceMenu(IUserService userService, IMenuElements menuElements)
    {
        _userService = userService;
        _menuElements = menuElements;

        consoleKey = ConsoleKey.D3;
        Name = "Are You Sure? ";
        Description = "Log Out";
        KeyDescription = "3";
    }

    public void Run()
    {

        bool validChoice = false;
        (bool, string) requestState = (true, string.Empty);
        ConsoleKey choice;
        do
        {
            _menuElements.PrintMenuTitle(Name, true);
            Console.WriteLine($"{"Y",-_distantiator}{"Yes",_distantiator}");
            Console.WriteLine($"{"N",-_distantiator}{"No",_distantiator}");
            Console.WriteLine(_menuElements.SeparatorString);
            choice = Console.ReadKey(true).Key;
            if (choice == ConsoleKey.Y)
            {
                requestState = _userService.LogOut();
                validChoice = true;
            }
            else if (choice == ConsoleKey.N)
            {
                validChoice = true;
            }

        } while (!validChoice);

        if (!requestState.Item1)
        {
            _menuElements.PrintResultMessage(requestState.Item2, true, true);
        }


    }
}
