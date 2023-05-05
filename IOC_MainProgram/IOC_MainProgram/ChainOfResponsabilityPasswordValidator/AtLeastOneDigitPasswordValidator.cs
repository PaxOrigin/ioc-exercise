namespace IOCMainProgram.ChainOfResponsabilityPasswordValidator;

internal class AtLeastOneDigitPasswordValidator : PasswordValidatorBase
{

    public AtLeastOneDigitPasswordValidator(IPasswordValidator? passwordValidator = null) : base(passwordValidator)
    {

    }
    public override bool Validate(string password)
    {
        if (password.Any(p => char.IsNumber(p)))
        {
            if (_nextValidator is not null)
                return _nextValidator.Validate(password);
            return true;
        }
        return false;
    }
}