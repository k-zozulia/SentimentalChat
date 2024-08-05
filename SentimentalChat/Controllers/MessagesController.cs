using Microsoft.AspNetCore.Mvc;
using SentimentalChat.Data;

namespace SentimentalChat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private IMessageRepository messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        [HttpGet]
        public IEnumerable<Message> Get()
        {
            return messageRepository.GetMessages();
        }
    }
}
