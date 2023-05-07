using IOCMainProgram.ChainOfResponsabilityPasswordValidator;
using IOCMainProgram.Services;
using IOCMainProgram.TestApp.ConsoleApp.MenuServices;

using Microsoft.Extensions.Hosting;

namespace IOCMainProgram.TestApp.ConsoleApp;

public class ConsoleApp : IApp, IHostedService
{
    IUserService _userService;
    IPasswordValidator _passwordValidator;
    IMainMenuService _mainMenuService;
    public ConsoleApp(IUserService userService, IPasswordValidator validator, IMainMenuService mainMenu)
    {
        _passwordValidator = validator;
        _userService = userService;
        _mainMenuService = mainMenu;
    }

    public void Run()
    {
        throw new NotImplementedException();
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _mainMenuService.Run();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {

    }
}
