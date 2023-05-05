using CSVConverter;

using DatabaseHandler;
using DatabaseHandler.Repositories;

using FileSystemManager;

using IOCMainProgram.ChainOfResponsabilityPasswordValidator;
using IOCMainProgram.CreateFileNameClasses;
using IOCMainProgram.Services;
using IOCMainProgram.TestApp;
using IOCMainProgram.TestApp.TestApp1;

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

                service.AddScoped<IUserService, UserService>();
                service.AddScoped<IUserRepository, UserRepository>();
                service.AddTransient<IPasswordValidator>(_ => new AtLeastOneDigitPasswordValidator(validateSpecialChar));
                service.AddDbContext<CredentialDBContext>(options => options.UseSqlServer(connectionString));
                // service.AddSingleton<CredentialDBContext>();
                service.AddTransient<IFileWriter, FileWriter>();
                service.AddTransient<ICsvConverter, CsvConverter>();
                service.AddTransient<ICreateUserFileName, CreateUserFileName>();
                service.AddScoped<IApp, TestApp1>();


            });
    }
}
