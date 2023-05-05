namespace IOCMainProgram.ChainOfResponsabilityPasswordValidator;

internal class PasswordLenghtValidator : PasswordValidatorBase
{

    public PasswordLenghtValidator(IPasswordValidator? passwordValidator = null) : base(passwordValidator)
    {

    }
    public override bool Validate(string password)
    {
        if (password.Length >= 7)
        {
            if (_nextValidator is not null)
                return _nextValidator.Validate(password);
            return true;
        }
        return false;
    }
}
