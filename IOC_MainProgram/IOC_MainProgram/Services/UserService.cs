namespace IOCMainProgram.Services;

using ChainOfResponsabilityPasswordValidator;

using CSVConverter;

using DatabaseHandler.Models;
using DatabaseHandler.Repositories;

using ExternalModel;

using FileSystemManager;

using IOCMainProgram.CreateFileNameClasses;

public class UserService : IUserService
{
    private User? _loggedUser;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordValidator _passwordValidator;
    private readonly ICsvConverter _csvConverter;
    private readonly IFileWriter _fileWriter;
    private readonly ICreateUserFileName _createUserFileName;


    public UserService
        (IUserRepository userRepository,
        IPasswordValidator passwordValidator,
        ICsvConverter csvConverter,
        IFileWriter fileWriter,
        ICreateUserFileName createUserFileName
        )
    {
        _passwordValidator = passwordValidator;
        _userRepository = userRepository;
        _csvConverter = csvConverter;
        _fileWriter = fileWriter;
        _createUserFileName = createUserFileName;
    }

    public (bool, string) LogIn(string id, string password)
    {
        if (int.TryParse(id, out int idToSearch))
        {
            User? user = _userRepository.RetrieveUser(idToSearch);
            if (_loggedUser is not null)
                LogOut();
            if (user is not null)
            {
                _loggedUser = user;
                return (true, "successfully logged in");

            }
            return (false, "Check your credentials and try again");

        }

        return (false, "Insert a valid id in numeric format");

    }

    public (bool, string) LogOut()
    {
        if (_loggedUser is null)
            return (false, "No user currently logged in.");
        _loggedUser = null;
        return (true, "Successfully logged out.");
    }

    public (bool, string) PrintCredential()
    {
        if (_loggedUser is not null)
        {
            UserExternalModel userToPrint = new UserExternalModel(_loggedUser);
            string convertedToCsv = _csvConverter.ConvertToCsv(userToPrint);


            _fileWriter.WriteToFile(_createUserFileName.CreateFileName(userToPrint), convertedToCsv);
            return (true, "File Generated");

        }
        return (false, "You must Login first");
    }

    public (bool, string) SignUp(string email, string password)
    {
        if (_passwordValidator.Validate(password))
        {
            if (_userRepository.CheckExistance(email))
            {
                return (false, "A user with this email already exists in the database. ");
            }

            User newUser = new()
            {
                Email = email,
                Password = password,
                UserCreationDate = DateTime.Now,
            };

            _userRepository.AddUser(newUser);

            return (true, $"User Created, ID is: {_userRepository.RetrieveID(newUser)}");
        }

        return (false, "Password is not valid.");
    }
}
