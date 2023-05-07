namespace IOCMainProgram.ChainOfResponsabilityPasswordValidator;

internal abstract class PasswordValidatorBase : IPasswordValidator
{
    protected IPasswordValidator? _nextValidator;

    internal PasswordValidatorBase(IPasswordValidator? nextValidator = null)
    {
        _nextValidator = nextValidator;
    }

    public abstract bool Validate(string? password);
}
