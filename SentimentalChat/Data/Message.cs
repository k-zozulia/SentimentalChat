using System.ComponentModel.DataAnnotations;

namespace SentimentalChat.Data
{
    public class Message
    {
        [Key]
        public int Order { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string MessageContent { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Sentiment {  get; set; }
    }
}
