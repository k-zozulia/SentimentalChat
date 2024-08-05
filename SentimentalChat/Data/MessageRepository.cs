namespace SentimentalChat.Data
{
    public class MessageRepository : IMessageRepository
    {
        private DBAccess db;

        public MessageRepository(DBAccess db) 
        {
            this.db = db;
        }

        public void AddMessage(Message message)
        {
            db.Messages.Add(message);

            db.SaveChanges();
        }

        public IEnumerable<Message> GetMessages()
        {
            return db.Messages.OrderBy(x => x.Order).ToList();
        }
    }
}
