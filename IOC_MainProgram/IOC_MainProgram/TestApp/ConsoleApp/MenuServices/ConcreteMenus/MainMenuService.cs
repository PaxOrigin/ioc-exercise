namespace IOCMainProgram.TestApp.ConsoleApp.MenuServices.ConcreteMenus;

using DatabaseHandler.Models;

using IOCMainProgram.Services;
using IOCMainProgram.TestApp.ConsoleApp.MenuServices;
using IOCMainProgram.TestApp.ConsoleApp.MenuServices.MenuFunctions;

using System;

public class MainMenuService : IMainMenuService
{
    private const int _distantiator = 22;

    private readonly ISignUpMenuService _signUpMenuService;

    private readonly IUserService _userService;

    private readonly IMenuElements _menuElements;

    private readonly ILoginMenuService _loginMenuService;

    private readonly ILogoutServiceMenu _logoutMenuService;

    private readonly ConsoleKey _exitConsoleKey = ConsoleKey.Escape;

    public string Name { get; private set; }

    public ConsoleKey? consoleKey { get; private set; }

    public MainMenuService(
        IUserService userService,
        ISignUpMenuService signUpMenuService,
        ILoginMenuService loginMenuService,
        IMenuElements menuElements,
        ILogoutServiceMenu logoutMenuService
        )
    {
        _signUpMenuService = signUpMenuService;
        _loginMenuService = loginMenuService;
        _userService = userService;
        _logoutMenuService = logoutMenuService;
        Name = "Main Menu";
        consoleKey = null;
        _menuElements = menuElements;
    }

    public void Run()
    {
        Console.CursorVisible = false;
        (bool, string) printAttempt = (true, string.Empty);
        ConsoleKey choice;
        do
        {
            PrintMenu();
            choice = Console.ReadKey(true).Key;
            if (choice == _signUpMenuService.consoleKey)
            {
                _signUpMenuService.Run();
            }
            else if (choice == _loginMenuService.consoleKey)
            {
                _loginMenuService.Run();
            }
            else if (choice == _logoutMenuService.consoleKey)
            {
                _logoutMenuService.Run();
            }
            else if (choice == ConsoleKey.D4)
            {
                printAttempt = _userService.PrintCredential();
                ConsoleColor color;
                if (printAttempt.Item1)
                    color = ConsoleColor.Green;
                else
                    color = ConsoleColor.Red;
                _menuElements.PrintResultMessage($"{printAttempt.Item2,-_distantiator}{"Press any button...",_distantiator}", true, true, color);
            }
        } while (choice != _exitConsoleKey);
    }

    private void PrintMenu()
    {


        _menuElements.PrintMenuTitle(Name, true, false);
        Console.WriteLine($"{_signUpMenuService.KeyDescription,-_distantiator}{_signUpMenuService.Name,_distantiator}");
        Console.WriteLine($"{_loginMenuService.KeyDescription,-_distantiator}{_loginMenuService.Name,_distantiator}");
        Console.WriteLine($"{_logoutMenuService.KeyDescription,-_distantiator}{_logoutMenuService.Description,_distantiator}");
        Console.WriteLine($"{"4",-_distantiator}{"Print credential",_distantiator}");
        Console.WriteLine($"{"ESC",-_distantiator}{"Exit",_distantiator}");
        Console.WriteLine(_menuElements.SeparatorString);
        User? user = _userService.GetLoggedUser();
        string loggedState = user is null ? "No user is logged in." : $"Logged in with {user.Email}";
        Console.WriteLine(loggedState);
        Console.WriteLine(_menuElements.SeparatorString);
    }
}
