namespace DataFIFA.Core.Constants;

public static class ErrorConstants
{
    public static string CareerNotFound(Guid id) => $"Carreira com id {id} n�o encontrada.";
    public static string UserNotFound(Guid id) => $"Usu�rio com Id {id} n�o encontrado.";
    public static string PlayerNotFound(Guid id) => $"Jogador com Id {id} n�o encontrado.";
    public static string TeamNotFound(Guid id) => $"Time com Id {id} n�o encontrado.";
    public static string EmailAlreadyRegistered => "E-mail already registered.";
}