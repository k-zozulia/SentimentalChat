
namespace SentimentalChat.Data
{
    public interface IMessageRepository
    {
        void AddMessage(Message message);
        IEnumerable<Message> GetMessages();
    }
}