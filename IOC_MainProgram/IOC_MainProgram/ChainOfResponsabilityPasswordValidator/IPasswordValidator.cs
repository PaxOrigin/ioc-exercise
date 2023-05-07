namespace IOCMainProgram.ChainOfResponsabilityPasswordValidator;

public interface IPasswordValidator
{
    public bool Validate(string? password);
}
