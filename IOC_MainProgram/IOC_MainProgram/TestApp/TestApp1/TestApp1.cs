using IOCMainProgram.Services;

using Microsoft.Extensions.Hosting;

namespace IOCMainProgram.TestApp.TestApp1;

public class TestApp1 : IApp, IHostedService
{

    IUserService _userService;

    public TestApp1(IUserService userService)
    {
        _userService = userService;
    }

    public void Run()
    {
        (string, string) credential1 = ("Alessandrobb@gmail.com", "Anton!ino1997");
        (string, string) credential2 = ("Giovanotti@gmail.com", "aaaaaa");
        (string, string) credential3 = ("Franca31@gmail.com", "Barbagianni1");
        (string, string) credential4 = ("VeteranPlayer@gmail.com", "Giovinciello13!!");
        (string, string) credential5 = ("MajorFriend@gmail.com", "Farantaranta1234$");
        (string, string) credential6 = ("Gandrestar@gmail.com", "GrandeCamo00^");



        Console.WriteLine($"Login con utente. email: {credential1.Item1}, psw: {credential1.Item2}");
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
            Console.WriteLine($"Signup con utente. email: {item.Item1}, psw: {item.Item2}");
            (bool, string) result = _userService.SignUp(item.Item1, item.Item2);
            if (result.Item1)
            {
                Console.WriteLine(result.Item2);
            }
            Console.WriteLine();

        }


    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {


    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {

    }
}
