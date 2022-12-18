namespace DataFIFA.Core.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string entity, Guid id) : base($"{entity} with Id {id} not found.")
    {
        
    }
}