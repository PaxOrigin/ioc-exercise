using IOCMainProgram.IOC;
using IOCMainProgram.TestApp;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IOCMainProgram;

public class Program
{
    static void Main(string[] args)
    {
        var host = Startup.CreateHostBuilder().Build();
        host.Services.GetService<IApp>()!.Run();

    }

}