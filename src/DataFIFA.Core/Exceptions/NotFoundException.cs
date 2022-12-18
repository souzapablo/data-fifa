namespace DataFIFA.Core.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string entity, Guid id) : base($"{entity} with Id {id} not found.")
    {
        
    }
}