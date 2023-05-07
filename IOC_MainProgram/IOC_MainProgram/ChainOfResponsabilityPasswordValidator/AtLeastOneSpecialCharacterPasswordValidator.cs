namespace IOCMainProgram.ChainOfResponsabilityPasswordValidator;

internal class AtLEastOneSpecialCharacterPasswordValidator : PasswordValidatorBase
{
    public AtLEastOneSpecialCharacterPasswordValidator(IPasswordValidator? passwordValidator = null) : base(passwordValidator)
    {

    }

    public override bool Validate(string? password)
    {
        if (!password.All(p => char.IsLetterOrDigit(p)))
        {
            if (_nextValidator is not null)
                return _nextValidator.Validate(password);
            return true;
        }
        return false;
    }
}