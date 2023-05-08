using CSVConverter;

using DatabaseHandler;
using DatabaseHandler.Repositories;

using FileSystemManager;

using IOCMainProgram.ChainOfResponsabilityPasswordValidator;
using IOCMainProgram.CreateFileNameClasses;
using IOCMainProgram.Services;
using IOCMainProgram.TestApp.ConsoleApp;
using IOCMainProgram.TestApp.ConsoleApp.MenuServices;
using IOCMainProgram.TestApp.ConsoleApp.MenuServices.ConcreteMenus;
using IOCMainProgram.TestApp.ConsoleApp.MenuServices.MenuFunctions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IOCMainProgram.IOC;
public static class Startup
{
    public static IHostBuilder CreateHostBuilder()
    {
        var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, service)
            =>
            {
                IPasswordValidator validator = new PasswordLenghtValidator();
                IPasswordValidator validateUpper = new UpperLetterPasswordValidator(validator);
                IPasswordValidator validateSpecialChar = new AtLEastOneSpecialCharacterPasswordValidator(validateUpper);

                string? connectionString = context.Configuration.GetConnectionString("DB1");
                string? filePath = context.Configuration.GetSection("FilePath").GetValue<string>("Path");

                service.AddSingleton<IUserService, UserService>();
                service.AddScoped<IUserRepository, UserRepository>();
                service.AddDbContext<CredentialDBContext>(options => options.UseSqlServer(connectionString));
                service.AddTransient<IPasswordValidator>(_ => new AtLeastOneDigitPasswordValidator(validateSpecialChar));
                service.AddTransient<IFileWriter>(_ => new FileWriter(filePath));
                service.AddTransient<ICsvConverter, CsvConverter>();
                service.AddTransient<ICreateUserFileName, CreateUserFileName>();
                service.AddTransient<IMainMenuService, MainMenuService>();
                service.AddTransient<ISignUpMenuService, SignupMenuService>();
                service.AddTransient<IMenuElements, MenuElements>();
                service.AddTransient<ILoginMenuService, LoginMenuService>();
                service.AddTransient<IConsoleStringReader, ConsoleStringReader>();
                service.AddTransient<ILogoutServiceMenu, LogOutServiceMenu>();
                service.AddHostedService<ConsoleApp>();


            });

    }
}
