namespace IOCMainProgram.TestApp.ConsoleApp.MenuServices;

public interface IMainMenuService
{
    public string Name { get; }
    public ConsoleKey? consoleKey { get; }
    public void Run();
}
