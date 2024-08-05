using Microsoft.AspNetCore.SignalR;
using SentimentalChat.AI;
using SentimentalChat.Data;

namespace SentimentalChat
{
    public class ChatHub : Hub
    {
        public const string BROADCAST_EVENT = "broadcastMessage";

        private IMessageRepository messageRepository;
        private ISentimentAnalizer analizer;

        public ChatHub(IMessageRepository messageRepository, ISentimentAnalizer analizer)
        {
            this.messageRepository = messageRepository;
            this.analizer = analizer;
        }

        public Task BroadcastMessage(Message message)
        {
            // Modify message
            message.Date = DateTime.Now;

            message.Sentiment = analizer.AnalizeMessage(message.MessageContent);

            // Save message to DB
            messageRepository.AddMessage(message);

            // Broadcast message to all clients
            return Clients.All.SendAsync(BROADCAST_EVENT, message);
        }
    }
}
