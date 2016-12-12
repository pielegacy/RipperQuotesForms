using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace RipperQuotes
{
    public class Quote
    {
        public int QuoteId { get; set; }
        public int TopicId { get; set; }
        public string QuoteText { get; set; }
        public string QuoteAuthor { get; set; }
        public Topic Topic { get; set; }
        public string QuoteTextPresent
        {
            get
            {
                return $"\"{QuoteText}\"";
            }
        }
        public string QuoteAuthorPresent
        {
            get
            {
                return $"~ {QuoteAuthor}, Part of {Topic.TopicName}";
            }
        }
        [JsonConstructor]
        public Quote()
        { }
    }
    public class Topic
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string TopicDescription { get; set; }
        public string TopicPassword { get; set; }
        public int TopicAmount { get; set; }

    }
    public class RipperCon
    {
        private List<Quote> _quotes = new List<Quote>();
        private List<Topic> _topics = new List<Topic>();
        public RipperCon()
        {

        }
        public async Task<string> DownloadJson()
        {
            string quoteString;
            string topicString;
            using (HttpClient client = new HttpClient())
            {
                quoteString = await client.GetStringAsync(new Uri("http://ripperquotes.azurewebsites.net/api/QuotesApi"));
                topicString = await client.GetStringAsync(new Uri("http://ripperquotes.azurewebsites.net/api/TopicsApi"));
            }
            _quotes = JsonConvert.DeserializeObject<List<Quote>>(quoteString);
            _topics = JsonConvert.DeserializeObject<List<Topic>>(topicString);
            return $"{quoteString},{topicString}";      
        }
        public List<Quote> Quotes
        {
            get
            {
                return _quotes;
            }
        }
        public List<Topic> Topics
        {
            get
            {
                return _topics;
            }
        }
    }
}
