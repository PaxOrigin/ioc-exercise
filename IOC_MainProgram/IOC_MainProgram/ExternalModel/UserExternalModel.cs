namespace IOCMainProgram.ExternalModel;

using CSVConverter;

using DatabaseHandler.Models;

using System.Collections.Generic;

public class UserExternalModel : IConvertibleToCsv
{
    public readonly User _user;
    public UserExternalModel(User user)
    {
        _user = user;
    }

    public List<string> ConvertFieldsToStringList()
    {
        List<string> fields = new List<string>
        {
            _user.Id.ToString(),
            _user.Email,
            _user.Password,
            _user.UserCreationDate.ToString("yyyy MM dd")
        };
        return fields;

    }
}
