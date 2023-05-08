using IOCMainProgram.TestApp.ConsoleApp.MenuServices;

using Microsoft.Extensions.Hosting;

namespace IOCMainProgram.TestApp.ConsoleApp;

public class ConsoleApp : IApp, IHostedService
{
    IMainMenuService _mainMenuService;
    public ConsoleApp(IMainMenuService mainMenu)
    {
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
