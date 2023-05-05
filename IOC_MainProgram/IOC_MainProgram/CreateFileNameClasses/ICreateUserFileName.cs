using IOCMainProgram.ExternalModel;

namespace IOCMainProgram.CreateFileNameClasses;

public interface ICreateUserFileName
{
    public string CreateFileName(UserExternalModel user);
}
