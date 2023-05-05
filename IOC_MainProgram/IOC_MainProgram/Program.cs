using IOCMainProgram.IOC;
using IOCMainProgram.TestApp;

using Microsoft.Extensions.DependencyInjection;


namespace IOCMainProgram;

public class Program
{
    static void Main(string[] args)
    {
        var host = Startup.CreateHostBuilder().Build();
        host.Services.GetService<IApp>()!.Run();

    }

}