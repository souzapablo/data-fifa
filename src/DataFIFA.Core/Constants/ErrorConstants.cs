namespace DataFIFA.Core.Constants;

public static class ErrorConstants
{
    public static string EntityNotFound(string entity, Guid id) => $"{entity} with id {id} not found.";
    public static string EmailAlreadyRegistered => "E-mail already registered.";
}