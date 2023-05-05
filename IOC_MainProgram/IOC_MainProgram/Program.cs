using IOCMainProgram.IOC;
using IOCMainProgram.TestApp;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IOCMainProgram;

public class Program
{
    static void Main(string[] args)
    {
        Startup.CreateHostBuilder().Build().Run();
        // host.Services.GetService<IApp>()!.Run();

    }

}