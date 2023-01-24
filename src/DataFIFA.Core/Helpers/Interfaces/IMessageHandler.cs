namespace DataFIFA.Core.Helpers.Interfaces;

public interface IMessageHandler
{
    List<ErrorMessage> Messages { get; }
    bool HasMessage { get; }
    void AddMessage(ErrorMessage errorMessage);
    void AddRangeMessages(List<ErrorMessage> errorMessage);
}