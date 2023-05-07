namespace IOCMainProgram.TestApp.ConsoleApp.MenuServices.MenuFunctions;

public class MenuElements : IMenuElements
{
    private const int _lenght = 50;
    private const char _character = '=';
    public string SeparatorString { get; private set; }

    public MenuElements()
    {
        SeparatorString = new string(_character, _lenght);
    }

    public string GetSeparatorString(int lenght = _lenght, char character = _character)
    {
        return new string(character, lenght);
    }

    public void PrintMenuTitle(string message, bool clearConsole = false, bool waitAtTheEnd = false)
    {
        if (clearConsole)
        {
            Console.Clear();
        }

        Console.WriteLine(SeparatorString);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
        Console.WriteLine(SeparatorString);

        if (waitAtTheEnd)
        {
            Console.ReadKey();
        }
    }

    public void PrintResultMessage(string message, bool clearConsole = false, bool waitAtTheEnd = false, ConsoleColor color = ConsoleColor.Red)
    {

        if (clearConsole)
        {
            Console.Clear();
        }

        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();

        if (waitAtTheEnd)
        {
            Console.ReadKey();
        }
    }
}
