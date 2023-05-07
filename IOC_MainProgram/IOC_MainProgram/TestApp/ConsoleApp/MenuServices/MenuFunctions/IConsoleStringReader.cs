namespace IOCMainProgram.TestApp.ConsoleApp.MenuServices.MenuFunctions;

public interface IConsoleStringReader
{
    public string? GetString(string message, ConsoleColor color = ConsoleColor.Green, bool showCursor = true);
}
