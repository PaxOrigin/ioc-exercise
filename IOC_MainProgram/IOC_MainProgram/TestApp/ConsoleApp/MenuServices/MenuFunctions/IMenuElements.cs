namespace IOCMainProgram.TestApp.ConsoleApp.MenuServices.MenuFunctions
{
    public interface IMenuElements
    {

        public string SeparatorString { get; }
        public string GetSeparatorString(int lenght, char character);
        public void PrintMenuTitle(string message, bool clearConsole = false, bool waitAtTheEnd = false);
        public void PrintResultMessage(string message, bool clearConsole = false, bool waitAtTheEnd = false, ConsoleColor color = ConsoleColor.Red);
    }
}