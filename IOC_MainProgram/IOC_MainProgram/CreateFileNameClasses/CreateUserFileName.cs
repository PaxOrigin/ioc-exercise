using IOCMainProgram.ExternalModel;

using System.Text;

namespace IOCMainProgram.CreateFileNameClasses;

public class CreateUserFileName : ICreateUserFileName
{
    public string CreateFileName(UserExternalModel user)
    {

        StringBuilder filename = new StringBuilder();
        filename.Append(user._user.Id);
        filename.Append('-');
        filename.Append(user._user.UserCreationDate.Year.ToString());
        filename.Append('-');
        filename.Append(user._user.UserCreationDate.Month.ToString());
        filename.Append('-');
        filename.Append(user._user.UserCreationDate.Day.ToString());
        filename.Append(".csv");
        return filename.ToString();
    }
}
