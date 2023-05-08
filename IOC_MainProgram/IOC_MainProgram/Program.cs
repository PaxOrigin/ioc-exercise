using IOCMainProgram.IOC;

using Microsoft.Extensions.Hosting;

namespace IOCMainProgram;

public class Program
{
    static void Main(string[] args)
    {
        Startup.CreateHostBuilder().Build().Run();
    }

}