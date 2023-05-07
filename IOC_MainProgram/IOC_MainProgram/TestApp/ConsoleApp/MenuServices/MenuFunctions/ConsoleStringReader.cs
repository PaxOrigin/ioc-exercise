namespace IOCMainProgram.TestApp.ConsoleApp.MenuServices.MenuFunctions;

public class ConsoleStringReader : IConsoleStringReader
{
    public string? GetString(string message, ConsoleColor color = ConsoleColor.Green, bool showCursor = true)
    {
        if (showCursor)
        {
            Console.CursorVisible = true;
        }
        string? inputString;
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
        inputString = Console.ReadLine();
        Console.CursorVisible = false;
        return inputString;
    }
}
