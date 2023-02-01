namespace DataFIFA.Core.Constants;

public static class ErrorConstants
{
    public static string CareerNotFound(Guid id) => $"Carreira com id {id} não encontrada.";
    public static string UserNotFound(Guid id) => $"Usuário com id {id} não encontrado.";
    public static string PlayerNotFound(Guid id) => $"Jogador com id {id} não encontrado.";
    public static string TeamNotFound(Guid id) => $"Time com id {id} não encontrado.";
    public static string EmailAlreadyRegistered => "E-mail inválido ou já cadastrado.";
    public static string InvalidUserNameOrPassword => "Usuário ou senha inválidos.";
    public static string InitialTeamNotFound(string initialTeamName) => $"Time {initialTeamName} não encontrado.";
}