using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailHw
{
    public class MailDisplay
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("sender")]
        public string Sender { get; set; }
        [JsonProperty("time")]
        public DateTime? TimeSent { get; set; }
        [JsonProperty("subject")]
        public string Subject { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
