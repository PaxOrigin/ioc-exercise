namespace IOCMainProgram.ChainOfResponsabilityPasswordValidator;

internal class UpperLetterPasswordValidator : PasswordValidatorBase
{

    public UpperLetterPasswordValidator(IPasswordValidator? passwordValidator = null) : base(passwordValidator)
    {

    }

    public override bool Validate(string? password)
    {
        if (password.Any(p => char.IsUpper(p)))
        {
            if (_nextValidator is not null)
                return _nextValidator.Validate(password);
            return true;
        }
        return false;
    }
}