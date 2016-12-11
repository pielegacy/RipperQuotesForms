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
        public string QuoteText { get; set; }
        public string QuoteAuthor { get; set; }
    }
    public class RipperCon
    {
        private List<Quote> _quotes = new List<Quote>();
        public RipperCon()
        {

        }
        public async Task<string> DownloadJson()
        {
            string jsonString;
            using (HttpClient client = new HttpClient())
            {
                jsonString = await client.GetStringAsync(new Uri("http://ripperquotes.azurewebsites.net/api/QuotesApi"));
            }
            _quotes = JsonConvert.DeserializeObject<List<Quote>>(jsonString);
            return jsonString;
        }
        public List<Quote> Quotes
        {
            get
            {
                return _quotes;
            }
        }

    }
}
