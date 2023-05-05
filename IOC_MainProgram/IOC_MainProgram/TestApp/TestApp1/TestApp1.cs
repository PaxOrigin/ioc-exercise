using IOCMainProgram.Services;

using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using DatabaseHandler;
using System.Text;

namespace IOCMainProgram.TestApp.TestApp1;

public class TestApp1 : IApp, IHostedService
{

    IUserService _userService;
    CredentialDBContext _credentialDbContext;

    public TestApp1(IUserService userService, CredentialDBContext credentialDBContext)
    {
        _userService = userService;
        _credentialDbContext = credentialDBContext;
    }

    public void Run()
    {
        StringBuilder sb = new StringBuilder();
        _credentialDbContext.Database.EnsureDeleted();
        _credentialDbContext.Database.EnsureCreated();

        (string, string) credential1 = ("Alessandrobb@gmail.com", "Anton!ino1997");
        (string, string) credential2 = ("Giovanotti@gmail.com", "aaaaaa");
        (string, string) credential3 = ("Franca31@gmail.com", "Barbagianni1");
        (string, string) credential4 = ("VeteranPlayer@gmail.com", "Giovinciello13!!");
        (string, string) credential5 = ("MajorFriend@gmail.com", "Farantaranta1234$");
        (string, string) credential6 = ("Gandrestar@gmail.com", "GrandeCamo00^");



        sb.AppendLine($"Login con utente. email: {credential1.Item1}, psw: {credential1.Item2}");
        _userService.LogIn(credential1.Item1, credential1.Item2);

        List<(string, string)> credentials = new List<(string, string)>()
        {
            credential1,
            credential2,
            credential3,
            credential4,
            credential5,
            credential6
        };

        foreach (var item in credentials)
        {
            sb.AppendLine($"Signup con utente. email: {item.Item1}, psw: {item.Item2}");
            (bool, string) result = _userService.SignUp(item.Item1, item.Item2);
            if (result.Item1)
            {
                sb.AppendLine(result.Item2);
            }
            else
            {
                sb.AppendLine(result.Item2);
            }

        }

        // Login con un utente
        sb.AppendLine("Loggin in with VeteranPlayer");
        var a = _userService.LogIn("2", "Giovinciello13!!");
        sb.AppendLine(a.Item2);
        var b = _userService.PrintCredential();
        sb.AppendLine(b.Item2);



        File.WriteAllText(Directory.GetCurrentDirectory() + @"\ProgramResult.txt", sb.ToString());

    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        StringBuilder sb = new StringBuilder();
        _credentialDbContext.Database.EnsureDeleted();
        _credentialDbContext.Database.EnsureCreated();

        (string, string) credential1 = ("Alessandrobb@gmail.com", "Anton!ino1997");
        (string, string) credential2 = ("Giovanotti@gmail.com", "aaaaaa");
        (string, string) credential3 = ("Franca31@gmail.com", "Barbagianni1");
        (string, string) credential4 = ("VeteranPlayer@gmail.com", "Giovinciello13!!");
        (string, string) credential5 = ("MajorFriend@gmail.com", "Farantaranta1234$");
        (string, string) credential6 = ("Gandrestar@gmail.com", "GrandeCamo00^");



        sb.AppendLine($"Login con utente. email: {credential1.Item1}, psw: {credential1.Item2}");
        _userService.LogIn(credential1.Item1, credential1.Item2);

        List<(string, string)> credentials = new List<(string, string)>()
        {
            credential1,
            credential2,
            credential3,
            credential4,
            credential5,
            credential6
        };

        foreach (var item in credentials)
        {
            sb.AppendLine($"Signup con utente. email: {item.Item1}, psw: {item.Item2}");
            (bool, string) result = _userService.SignUp(item.Item1, item.Item2);
            if (result.Item1)
            {
                sb.AppendLine(result.Item2);
            }
            else
            { 
                sb.AppendLine(result.Item2);
            }

        }

        // Login con un utente
        sb.AppendLine("Loggin in with VeteranPlayer");
        var a = _userService.LogIn("2", "Giovinciello13!!");
        sb.AppendLine(a.Item2);
        var b = _userService.PrintCredential();
        sb.AppendLine(b.Item2);



        File.WriteAllText(Directory.GetCurrentDirectory() + @"\ProgramResult.txt", sb.ToString());

    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {

    }
}
