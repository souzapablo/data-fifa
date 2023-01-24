using DataFIFA.Core.Helpers.Interfaces;

namespace DataFIFA.Core.Helpers;

public class MessageHandler : IMessageHandler
{
    public MessageHandler()
    {
        Messages = new List<ErrorMessage>();
    }
    
    public List<ErrorMessage> Messages { get; }

    public bool HasMessage => Messages.Any();

    public void AddMessage(ErrorMessage message) => Messages.Add(message);

    public void AddRangeMessages(List<ErrorMessage> errorMessage) => Messages.AddRange(errorMessage);
}