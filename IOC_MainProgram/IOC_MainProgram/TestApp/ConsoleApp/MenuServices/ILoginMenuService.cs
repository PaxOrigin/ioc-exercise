﻿namespace IOCMainProgram.TestApp.ConsoleApp.MenuServices;

public interface ILoginMenuService
{
    public string Name { get; }
    public string Description { get; }
    public string KeyDescription { get; }
    public ConsoleKey? consoleKey { get; }
    public void Run();
}
