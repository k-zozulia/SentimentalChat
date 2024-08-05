using Azure;
using Azure.AI.TextAnalytics;

namespace SentimentalChat.AI
{
    public class SentimentAnalizer : ISentimentAnalizer
    {
        private TextAnalyticsClient client;

        public SentimentAnalizer(string endpoint, string key)
        {
            Uri endpointUri = new Uri(endpoint);

            AzureKeyCredential credential = new AzureKeyCredential(key);

            client = new TextAnalyticsClient(endpointUri, credential);
        }

        public string AnalizeMessage(string message)
        {
            var result = client.AnalyzeSentiment(message);

            if (result == null || result.Value == null)
            {
                return "";
            }

            return result.Value.Sentiment.ToString();
        }
    }
}
