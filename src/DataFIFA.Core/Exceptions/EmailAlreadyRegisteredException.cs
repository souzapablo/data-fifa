namespace DataFIFA.Core.Exceptions;

public class EmailAlreadyRegisteredException : Exception
{
    public EmailAlreadyRegisteredException() : base ($"E-mail already registered.")
    {
        
    }
}