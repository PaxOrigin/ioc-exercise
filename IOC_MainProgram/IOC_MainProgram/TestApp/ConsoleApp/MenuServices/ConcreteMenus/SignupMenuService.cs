using IOCMainProgram.ChainOfResponsabilityPasswordValidator;
using IOCMainProgram.Services;
using IOCMainProgram.TestApp.ConsoleApp.MenuServices.MenuFunctions;

namespace IOCMainProgram.TestApp.ConsoleApp.MenuServices.ConcreteMenus;

public class SignupMenuService : ISignUpMenuService
{
    private IUserService _userService;

    private readonly IMenuElements _menuElements;

    private readonly IConsoleStringReader _consoleStringReader;

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string KeyDescription { get; private set; }

    public ConsoleKey? consoleKey { get; private set; }


    public SignupMenuService(IUserService userService, IPasswordValidator passwordValidator, IMenuElements menuElements, IConsoleStringReader consoleStringReader)
    {
        _userService = userService;
        Name = "Sign Up";
        Description = "Create an Account";
        KeyDescription = "1";
        consoleKey = ConsoleKey.D1;
        _menuElements = menuElements;
        _consoleStringReader = consoleStringReader;
    }


    public void Run()
    {
        string? email;
        string? password;
        (bool, string) requestState = (true, string.Empty);

        do
        {
            Console.Clear();
            if (!requestState.Item1)
                _menuElements.PrintResultMessage(requestState.Item2);
            _menuElements.PrintMenuTitle(Name);
            Console.CursorVisible = true;
            email = _consoleStringReader.GetString("Email: ");
            password = _consoleStringReader.GetString("Password:");
            Console.CursorVisible = false;
            requestState = _userService.SignUp(email, password);

        } while (!requestState.Item1);

        _menuElements.PrintMenuTitle($"{requestState.Item2}{Environment.NewLine}Press any button to exit.", true, true);
    }

}
